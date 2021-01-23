    using (Bitmap bmp = new Bitmap(pictureBox1.Image))
    {
        var newImg = bmp.Clone(
            new Rectangle { X = 10, Y = 10, Width = bmp.Width / 2, Height = bmp.Height / 2 }, 
            bmp.PixelFormat);
        pictureBox2.Image = newImg;
    }
