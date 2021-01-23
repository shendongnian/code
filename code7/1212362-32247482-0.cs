     using System.Runtime.InteropServices;
     ...
        private void panel1_Scroll(object sender, ScrollEventArgs e) {
            if (e.Type == ScrollEventType.First) {
                LockWindowUpdate(this.Handle);
            }
            else {
                LockWindowUpdate(IntPtr.Zero);
                panel1.Update();
                if (e.Type != ScrollEventType.Last) LockWindowUpdate(this.Handle);
            }
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool LockWindowUpdate(IntPtr hWnd);
