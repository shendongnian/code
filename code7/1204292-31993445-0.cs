    public const int HTCAPTION = 0x2;
    public const int WM_NCHITTEST = 0x84;
    public const int HTCLIENT = 1;
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == WM_NCHITTEST)
        {
            if (m.Result.ToInt32() == HTCLIENT)
                m.Result = (IntPtr)HTCAPTION;
        }
    }
