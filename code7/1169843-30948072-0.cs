            [DllImport("user32.dll")]
            static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);
            [DllImport("user32.dll")]
            static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
            internal const UInt32 SC_CLOSE = 0xF060;
            internal const UInt32 MF_ENABLED = 0x00000000;
            internal const UInt32 MF_GRAYED = 0x00000001;
            internal const UInt32 MF_DISABLED = 0x00000002;
            internal const uint MF_BYCOMMAND = 0x00000000;
    
    
            static void Main(string[] args)
            {
                EnableCloseButton(this, false);
            }
    
            public static void EnableCloseButton(IWin32Window window, bool bEnabled)
            {
                IntPtr hSystemMenu = GetSystemMenu(window.Handle, false);
                EnableMenuItem(hSystemMenu, SC_CLOSE, (uint)(MF_ENABLED | (bEnabled ? MF_ENABLED : MF_GRAYED)));
            }
