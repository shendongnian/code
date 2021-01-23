        Bitmap pic = new Bitmap("example.bmp");
        Bitmap pic2 = new Bitmap(pic.Width, pic.Height, PixelFormat.Format16bppRgb555);
        for (int x = 0; x < pic.Width; ++x)
        {
            for (int y = 0; y < pic.Height; ++y)
            {
                pic2.SetPixel(x, y, pic.GetPixel(x, y));
            }
        }
        pic2.RotateFlip(RotateFlipType.Rotate180FlipX);
        pic2.Save("test.bmp", ImageFormat.Bmp);
