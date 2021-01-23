        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (!SENDING_KEYS) //If we're sending keys, ignore everything below
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN) //KeyDown
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    string theKey = ((Keys)vkCode).ToString();
                    Console.Write(theKey);
                    if (theKey.Contains("ControlKey"))
                    {
                        //Our Program still thinks CTRL is down even if we send it using SendKeys
                        CONTROL_DOWN = true; 
                    }
                    else if (CONTROL_DOWN && theKey == "B")
                    {
                        Console.WriteLine("\n***HOTKEY PRESSED***"); //Our hotkey has been pressed
                        SENDING_KEYS = true; //Now we will be sending keys
                        SendKeys.Send("^v"); //Send the keys (CTRL+V) - Paste
                        SENDING_KEYS = false; //Now we are done sending the keys
                        return (IntPtr)1; //Block our hotkey from being sent anywhere
                    }
                    else if (theKey == "Escape")
                    {
                        UnhookWindowsHookEx(_hookID);
                        Environment.Exit(0);
                    }
                }
                else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP) //KeyUP
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    string theKey = ((Keys)vkCode).ToString();
                    if (theKey.Contains("ControlKey"))
                    {
                        //During send keys, this will not be triggered
                        CONTROL_DOWN = false; 
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
