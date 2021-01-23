     class ClipboardUtility : IDisposable
    {
        private bool disposed = false;
        //If the function succeeds, the return value is the handle to the window that has the clipboard open. 
        //If no window has the clipboard open, the return value is NULL. 
        //To get extended error information, call GetLastError. 
        [DllImport("user32.dll")]
        static extern IntPtr GetOpenClipboardWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool CloseClipboard();
        [DllImport("user32.dll")]
        static extern bool EmptyClipboard();
        private IntPtr ClipWindow;
        public void CheckSetClipboard(string s)
        {
            //IntPtr ClipWindow = GetOpenClipboardWindow();
              ClipWindow = GetOpenClipboardWindow();
            Console.WriteLine("handle IntPtr= {0}", ClipWindow);
            //  if (ClipWindow != null && ClipWindow != (IntPtr)0)
            if (ClipWindow != null )
            {
                Console.WriteLine("ClipWindow_" + ClipWindow.ToString());
                uint wid = GetWindowThreadProcessId(ClipWindow, out wid);
                Process p = Process.GetProcessById((int)wid);
                Console.WriteLine("Process using Clipboard: " + p.ProcessName);
            }
            else
            {
                Console.WriteLine("error: {0}", Marshal.GetLastWin32Error());
              //  Console.WriteLine("0 is not idle");
            }
            //Marshal.FreeHGlobal(ClipWindow);
            //OpenClipboard(IntPtr.Zero);
            //EmptyClipboard();
            //CloseClipboard();
            //Console.WriteLine("s: " + s);
            try
            {
                Clipboard.SetDataObject(s, true, 10, 50);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               // Clipboard.SetDataObject(s, true, 10, 50);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                CloseHandle(ClipWindow);
                ClipWindow = IntPtr.Zero;
                disposed = true;
            }
        }
        [DllImport("Kernal32")]
        private extern static Boolean CloseHandle(IntPtr handle);
    }
