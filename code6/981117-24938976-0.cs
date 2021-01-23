        private static int KeyCaptureCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int pointerCode = Marshal.ReadInt32(lParam);
                bool result = false;
                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    if (KeyDown != null)
                    {
                        result = KeyDown(pointerCode);
                    }
                }
                if (result)
                {
                    return 1;
                }
            }
            return CallNextHookEx(_keyCaptureHook, nCode, wParam, lParam);
        }
