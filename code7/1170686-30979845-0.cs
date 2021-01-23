        void Dispose(bool disposing) {
                    if (handle != IntPtr.Zero) {
        #if FINALIZATION_WATCH
                        if (!disposing) {
                            Debug.WriteLine("**********************\nDisposed through finalization:\n" + allocationSite);
                        }
        #endif
                        DestroyHandle();
                    }
                }
    
    internal void DestroyHandle() {
                if (ownHandle) {
                    SafeNativeMethods.DestroyIcon(new HandleRef(this, handle));
                    handle = IntPtr.Zero;
                }
            }
     
 
            public void Dispose() {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
     
            void Dispose(bool disposing) {
                if (handle != IntPtr.Zero) {
    #if FINALIZATION_WATCH
                    if (!disposing) {
                        Debug.WriteLine("**********************\nDisposed through finalization:\n" + allocationSite);
                    }
    #endif
                    DestroyHandle();
                }
            }
