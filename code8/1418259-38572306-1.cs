    void Example()
    {
        IntPtr hwnd = FindWindow(null, "Example.txt - Notepad2");
        CaptureWindow(hwnd);
    }
    [DllImport("User32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);
    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr handle, ref Rectangle rect);
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    public void CaptureWindow(IntPtr handle)
    {
        // Get the size of the window to capture
        Rectangle rect = new Rectangle();
        GetWindowRect(handle, ref rect);
        // GetWindowRect returns Top/Left and Bottom/Right, so fix it
        rect.Width = rect.Width - rect.X;
        rect.Height = rect.Height - rect.Y;
        // Create a bitmap to draw the capture into
        using (Bitmap bitmap = new Bitmap(rect.Width, rect.Height))
        {
            // Use PrintWindow to draw the window into our bitmap
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                IntPtr hdc = g.GetHdc();
                if (!PrintWindow(handle, hdc, 0))
                {
                    int error = Marshal.GetLastWin32Error();
                    var exception = new System.ComponentModel.Win32Exception(error);
                    Debug.WriteLine("ERROR: " + error + ": " + exception.Message);
                    // TODO: Throw the exception?
                }
                g.ReleaseHdc(hdc);
            }
            // Save it as a .png just to demo this
            bitmap.Save("Example.png");
        }
    }
