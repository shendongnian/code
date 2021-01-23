    $KeyPresser = Add-Type -MemberDefinition @"
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
    
    public static void PressOne(int press, int release)
    {
        //This code will press and hold the '1' button for 3 secs, and then will release for 1 second
        //VK_F15 0x7E
        keybd_event((byte)0x31, (byte)0x02, 0, UIntPtr.Zero);
        Thread.Sleep(press);
    
        keybd_event((byte)0x31, (byte)0x82, (uint)0x2, UIntPtr.Zero);
        Thread.Sleep(release);
    }
    
    public static void PressOne()
    {
        PressOne(3000, 1000);
    }
    "@ -Name PressKeyForMe -UsingNamespace System.Threading -PassThru
