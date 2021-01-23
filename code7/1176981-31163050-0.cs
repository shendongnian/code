    public Bitmap screenshot()
    {
         Bitmap shot = new Bitmap(SystemInformation.VirtualScreen.Width,
                    SystemInformation.VirtualScreen.Height,
                    PixelFormat.Format24bppRgb);
        Graphics screenGraph = Graphics.FromImage(shot);
        screenGraph.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                   Screen.PrimaryScreen.Bounds.Y,
                                   0,
                                   0,
                                   SystemInformation.VirtualScreen.Size,
                                   CopyPixelOperation.SourceCopy);
        return shot;
    }
