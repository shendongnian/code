    [DllImport("gdi32.dll")]
    static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
    public enum DeviceCap
    {
        VERTRES = 10,
        DESKTOPVERTRES = 117,
    }
    
    private float getScalingFactor()
    {
        using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
        {
            IntPtr desktop = g.GetHdc();
            try
            {
                int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
                int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);
                float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;
                return ScreenScalingFactor; 
            }
            finally
            {
                g.ReleaseHdc();
            }
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        using (Graphics myGraphics = this.CreateGraphics())
        {
            var factor = getScalingFactor();
            Size s = new Size((int)(this.Size.Width * factor), (int)(this.Size.Height * factor));
    
            using (Bitmap memoryImage = new Bitmap(s.Width, s.Height, myGraphics))
            {
                using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
                {
                    memoryGraphics.CopyFromScreen((int)(Location.X * factor), (int)(Location.Y * factor), 0, 0, s);
                    memoryImage.Save(@"D:\x.png", ImageFormat.Png);
                }
            }
        }
    }
