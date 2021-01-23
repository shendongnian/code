    private static void ConvertToImage(int size, bool fixWidth, bool fixHeight, Image img)
    {
        byte[] picbyte = img.Img;
        using (MemoryStream ms = new MemoryStream(picbyte))
        using (System.Drawing.Image image = System.Drawing.Image.FromStream(ms))
        { 
            int width = image.Width;
            int height = image.Height;
            if (fixWidth && !fixHeight)
            {
                height = (int)Math.Round(((decimal)height / width) * size);
                width = size;
            }
            if (fixHeight && !fixWidth)
            {
                width = (int)Math.Round(((decimal)width / height) * size);
                height = size;
            }
            if ((fixWidth && fixHeight) || (!fixWidth && !fixHeight))
            {
                width = size;
                height = size;
            }
            using(MemoryStream ms2 = new MemoryStream())
            using (var thumnailImage = image.GetThumbnailImage(width, height, delegate () { return false; }, IntPtr.Zero))
            { 
                thumnailImage.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                img.Img = ms2.ToArray();
                img.MIMEType = "image/png";
            }
        }
    }
