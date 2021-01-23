    [DllImport("user32.dll")]
    static extern bool ClientToScreen(IntPtr hWnd, ref System.Drawing.Point lpPoint);
    static Rectangle GetClientRect(IntPtr handle)
    {
        Rect rect;
        GetClientRect(handle, out rect);
        var p = new System.Drawing.Point(0, 0);
        ClientToScreen(handle, ref p);
        // rect.Left = rect.Top = 0, hence rect.Width = rect.Right, rect.Height = rect.Bottom
        return new Rectange(p.X, p.Y, rect.Right, rect.Bottom);
    }
