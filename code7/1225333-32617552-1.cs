    [System.Runtime.InteropServices.DllImport("user32.dll")]
    [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
    internal static extern bool GetCursorPos(ref PointStruct point);
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    internal struct PointStruct
    {
        public Int32 X;
        public Int32 Y;
    };
    public static System.Drawing.Point MousePosition()
    {
        var mousePosition = new PointStruct();
        GetCursorPos(ref mousePosition);
        return new System.Drawing.Point(mousePosition.X, mousePosition.Y);
    }
