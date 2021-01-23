    public static Bitmap CaptureScreen()
    {
        Rectangle bounds = SystemInformation.VirtualScreen;
    
        Bitmap Target = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppRgb);
    
        using (Graphics g = Graphics.FromImage(Target))
        {
            g.CopyFromScreen(0, 0, 0, 0, bounds.Size);
        }
    
        return Target;
    }
