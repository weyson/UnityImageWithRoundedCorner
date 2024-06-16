using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ImageWithRoundedCorner : MonoBehaviour
{
    public float Width;

    public float Height;

    public float CornerRadius;

    private Image mImage;
    private float mOriginalWidth;
    private float mOriginalHeight;
    private Material mMaterial;
    
    void Awake()
    {
        mImage = GetComponent<Image>();
        mOriginalWidth = mImage.sprite.rect.width;
        mOriginalHeight = mImage.sprite.rect.height;
        mMaterial = mImage.material;
        Debug.Log($"image width: {mOriginalWidth} height: {mOriginalHeight}");
    }

    void Update()
    {
        var x = (mOriginalWidth - Width) * 0.5f / mOriginalWidth;
        var y = (mOriginalHeight - Height) * 0.5f / mOriginalHeight;
        var w = Width / mOriginalWidth;
        var h = Height / mOriginalHeight;
        var ratio = mOriginalWidth / mOriginalHeight;
        mMaterial.SetVector("_ShowRect", new Vector4(x,y,w,h));
        mMaterial.SetVector("_CornerRadius", new Vector4(CornerRadius / mOriginalWidth, CornerRadius / mOriginalHeight, 0, 0));
    }
}
