    protected override void WndProc(ref Message m)
    {
        const int WM_NCHITTEST = 0x84;
        const int WM_SETCUROR = 0x20;
        const int HTCAPTION = 0x2;
        if (m.Msg == WM_NCHITTEST)
        {
            base.WndProc(ref m);
            m.Result = new IntPtr(HTCAPTION);
            return;
        }
        if (m.Msg == WM_SETCUROR)
        {
            if ((m.LParam.ToInt32() & 0xffff) == HTCAPTION)
            { 
                Cursor.Current = Cursors.SizeAll;
                m.Result = (IntPtr)1;  
                return;
            }
        }
        base.WndProc(ref m);
    }
