    public void screenShot(string path)
    {
        using (var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                        Screen.PrimaryScreen.Bounds.Height,
                                        PixelFormat.Format32bppArgb))
        {
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                    Screen.PrimaryScreen.Bounds.Y,
                                    0,
                                    0,
                                    Screen.PrimaryScreen.Bounds.Size,
                                    CopyPixelOperation.SourceCopy);
            bmpScreenshot.Save(path, ImageFormat.Png);
        }
    }
