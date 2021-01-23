        public bool InvokeRequired {
            get {
 
                using (new MultithreadSafeCallScope())
                {
                    HandleRef hwnd;
                    if (IsHandleCreated) {
                        hwnd = new HandleRef(this, Handle);
                    }
                    else {
                        Control marshalingControl = FindMarshalingControl();
 
                        if (!marshalingControl.IsHandleCreated) {
                            return false;
                        }
 
                        hwnd = new HandleRef(marshalingControl, marshalingControl.Handle);
                    }
 
                    int pid;
                    int hwndThread = SafeNativeMethods.GetWindowThreadProcessId(hwnd, out pid);
                    int currentThread = SafeNativeMethods.GetCurrentThreadId();
                    return(hwndThread != currentThread);
                }
            }
        }
