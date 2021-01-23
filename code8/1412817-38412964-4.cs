    public static extern int GetRawInputData(IntPtr hRawInput, RawInputCommand uiCommand, out RAWINPUT pData, ref int pcbSize, int cbSizeHeader);
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == (int)WindowMessages.RawInput)  // WindowMessages.RawInput = 0x00FF (WM_INPUT)
        {
            RAWINPUT input = new RAWINPUT();
            int outSize = 0;
            int size = Marshal.SizeOf(typeof(RAWINPUT));
            outSize = Win32API.GetRawInputData(m.LParam, RawInputCommand.Input, out input, ref size, Marshal.SizeOf(typeof(RAWINPUTHEADER)));
            if (outSize != -1)
            {
                if (input.Header.Type == RawInputType.Mouse)
                {
                    //input.Mouse.LastX;
                    //input.Mouse.LastY;
                }
            }
        }
        base.WndProc(ref m);
    }
