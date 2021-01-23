        /// <summary>
        /// A hook handle for grabbing mouse click, used to get the position of target window.
        /// </summary>
        private IntPtr _hook = IntPtr.Zero;
        //button click event
        private void selectWindow_Click(object sender, EventArgs e)
        {
            if (_hook != IntPtr.Zero)
                return;
            using (Process p = Process.GetCurrentProcess())
            {
                using (ProcessModule m = p.MainModule)
                {
                    _hook = SafeNativeMethods.SetWindowsHookEx(SafeNativeMethods.WH_MOUSE_LL, hookCallback, SafeNativeMethods.GetModuleHandle(m.ModuleName), 0);
                }
            }
        }
        /// <summary>
        /// Callback method of mouse hook.
        /// </summary>
        private IntPtr hookCallback(int code, IntPtr w, IntPtr l)
        {
            if (code >= 0 && (WMessages)w == WMessages.WM_LBUTTONDOWN)
            {
                CPoint pt;
                SafeNativeMethods.GetCursorPos(out pt);
                //hey man! the _windowHandle is what you need
                _windowHandle = SafeNativeMethods.WindowFromPoint(pt);
                SafeNativeMethods.UnhookWindowsHookEx(_hook);
                _hook = IntPtr.Zero;
                //...and do your stuff here!
            }
            return SafeNativeMethods.CallNextHookEx(_hook, code, w, l);
        }
