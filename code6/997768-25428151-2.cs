    protected override void WndProc(ref Message m)
    {
        if (m.Msg == (int)WindowsMessage.WM_NCHITTEST)
        {
            m.Result = (IntPtr)(-1);//Transparent
            return;
        }
        base.WndProc(ref m);
    }
