    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0112) // WM_SYSCOMMAND
        {
            if (m.WParam == new IntPtr(0xF030)) // Maximize event
            {
                Size = MaximumSize; //Set size manually and return
                return;
            }
        }
        base.WndProc(ref m);
    }
