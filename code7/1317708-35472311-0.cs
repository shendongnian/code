    protected override void WndProc(ref Message m)
    {
        if (m.Msg == NativeMethods.WM_SHOWME)
        {
            ShowMe();
            return;  // <-- right here!
        }
        base.WndProc(ref m);
    }
