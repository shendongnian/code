    [DllImport("user32.dll")]
    static extern IntPtr GetDC(IntPtr hWnd);
    [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError=true)]
    static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);
    [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
    static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);
    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst,
        ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pptSrc, uint crKey, 
            [In] ref BLENDFUNCTION pblend, uint dwFlags);
    [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
    static extern bool DeleteDC([In] IntPtr hdc);
    [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool DeleteObject([In] IntPtr hObject);
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        public int cx;
        public int cy;
        public SIZE(int cx, int cy)
        {
            this.cx = cx;
            this.cy = cy;
        }
    }
    public struct BLENDFUNCTION
    {
        public byte BlendOp;
        public byte BlendFlags;
        public byte SourceConstantAlpha;
        public byte AlphaFormat;
    }
