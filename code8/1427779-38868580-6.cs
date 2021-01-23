    private const int WS_SYSMENU = 0x80000;
    private const int WS_MINIMIZEBOX = 0x20000;
    private const int WS_MAXIMIZEBOX = 0x10000;
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams p = base.CreateParams;
            p.Style = WS_SYSMENU | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;
            return p;
        }
    }
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg,
        IntPtr wParam, IntPtr lParam);
    private const int WM_POPUPSYSTEMMENU = 0x313;
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            var p = MousePosition.X + (MousePosition.Y * 0x10000);
            SendMessage(this.Handle, WM_POPUPSYSTEMMENU, (IntPtr)0, (IntPtr)p);
        }
    }
