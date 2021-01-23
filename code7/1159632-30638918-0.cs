    if (GetRGB)
    {
        using (ColorFrame colorFrame = frame.ColorFrameReference.AcquireFrame ()) 
        {
            if (colorFrame != null)
            {
               colorFrame.CopyConvertedFrameDataToArray (_ColorData, ColorImageFormat.Rgba);
               _ColorTexture.LoadRawTextureData (_ColorData);
               _ColorTexture.Apply ();
               colorFrame.Dispose ();
               colorFrame = null;
            }
        }
    }
