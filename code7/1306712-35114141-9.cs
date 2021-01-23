    protected override void WndProc(ref Message message)
    {
        if (message.Msg == 0x0084) // WM_NCHITTEST
            message.Result = (IntPtr)1;   
        else base.WndProc(ref message);
    }
