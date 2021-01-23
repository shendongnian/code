    [DllImport("user32")]
    public static extern UInt32 SendMessage
        (IntPtr hWnd, UInt32 msg, UInt32 wParam, UInt32 lParam);
    
    internal const int BCM_FIRST = 0x1600; //Normal button
    internal const int BCM_SETSHIELD = (BCM_FIRST + 0x000C); //Elevated button
    
    static internal void AddShieldToButton(Button b)
    {
        b.FlatStyle = FlatStyle.System;
        SendMessage(b.Handle, BCM_SETSHIELD, 0, 0xFFFFFFFF);
    }
