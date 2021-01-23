        private IntPtr Callback(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam) {
            // Note: if you change this code be sure to change the 
            // corresponding code in DebuggableCallback below!
            Message m = Message.Create(hWnd, msg, wparam, lparam);
            try {
                if (weakThisPtr.IsAlive && weakThisPtr.Target != null) {
                    WndProc(ref m);
                }
                else {
                    DefWndProc(ref m);
                }
            }
            catch (Exception e) {
                OnThreadException(e);
            }
            finally {
                if (msg == NativeMethods.WM_NCDESTROY) ReleaseHandle(false);
                if (msg == NativeMethods.WM_UIUNSUBCLASS) ReleaseHandle(true);
            }
            return m.Result;
        }
