    Bitmap bmp1 = (Bitmap)pictureBox1.Image;
    Bitmap bmp2 = new Bitmap(bmp1.Width * 2, bmp1.Height);
    using (Graphics G = Graphics.FromImage(bmp2))
    {
        G.DrawImage(bmp1, 0, 0);
        bmp1.RotateFlip(RotateFlipType.RotateNoneFlipX);
        G.DrawImage(bmp1, bmp1.Width, 0);
        pictureBox2.Image = bmp2;
    }
