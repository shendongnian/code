    static bool ctrlPressed = false;
    static bool ctrlAPressed = false;
    public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
    {
        if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            if (vkCode == 162 || vkCode == 163) //162 is Left Ctrl, 163 is Right Ctrl
            {
                ctrlPressed = true;
            }
            else if (vkCode == 65 && ctrlPressed == true) // "A"
            {
                ctrlPressed = false;
                ctrlAPressed = true;
            }
            else if (vkCode == 83 && ctrlAPressed == true) // "S"
            {
                ctrlPressed = false;
                ctrlAPressed = false;
                MessageBox.Show("Bingo!");
            }
            else
            {
                ctrlPressed = false;
                ctrlAPressed = false;
            }
            // return (IntPtr)1; // note: this will interfere with keyboard processing for other apps
        }
    //  else // don't interfere , always return callnexthookex
            return CallNextHookEx(hhook, code, (int)wParam, lParam);
    }
