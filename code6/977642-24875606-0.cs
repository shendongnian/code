    public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            Keys pressedKey = (Keys)Marshal.ReadInt32(lParam);
            if (pressedKey == Keys.F11 || pressedKey == Keys.F12)
            {
                // Do something...
                // Don't pass the key press on to the system
                lParam = null;
            }
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }
