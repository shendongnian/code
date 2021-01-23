        EMPLOYER_SIGN = new Bitmap(426, 155);
        using (Graphics gr = Graphics.FromImage(EMPLOYER_SIGN))
        {
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gr.DrawImage(Image.FromFile("C:/SCR/temp/sign.jpg"), new Rectangle(0, 0, 426, 155));
        }
        MemoryStream ms = new MemoryStream();
        EMPLOYER_SIGN.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        BARRAY_EMPSIGN = ms.ToArray();
        ms.Dispose();
        pictureBox3.Image = EMPLOYER_SIGN;
