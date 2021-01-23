    protected override void WndProc(ref Message message)
    {
        if (message.Msg == 0x0084) // WM_NCHITTEST
            return;    
        base.WndProc(ref message);
    }
