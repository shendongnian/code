    byte[] bytes = Convert.FromBase64String(b64);
    using (MemoryStream ms = new MemoryStream(bytes))
    {
       
        Bitmap thumb = new Bitmap(100, 100);
        using (Image bmp = Image.FromStream(ms))
        {
            using (Graphics g = Graphics.FromImage(thumb))
            { 
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawImage(bmp, 0, 0, 100, 100);
            }
        }
        picOut.Image = thumb;
    }
