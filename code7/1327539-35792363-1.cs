    public byte[] MakeThumbnail(byte[] myImage, int thumbWidth, int thumbHeight)
    {
        using (MemoryStream ms = new MemoryStream())
        using (Image thumbnail = Image.FromStream(new MemoryStream(myImage)).GetThumbnailImage(thumbWidth, thumbHeight, null, new IntPtr()))
        {
            thumbnail.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
