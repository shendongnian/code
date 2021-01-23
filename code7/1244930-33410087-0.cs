    byte[] result;
    using (Image newImage = new Bitmap(origImage))
    {
        using (Graphics graphics = Graphics.FromImage(newImage))
        {
            // do some drawing
        }
        using (MemoryStream ms = new MemoryStream())
        {
            newImage.Save(ms, ImageFormat.Png);
            result = ms.ToArray();
        }
    }
