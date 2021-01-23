    class SpyAgent : NativeWindow {
        public SpyWindow(IntPtr hWnd) {
            this.AssignHandle(hWnd);
        }
        protected override void WndProc(ref Message m) {
            if (m.Msg == 130) this.ReleaseHandle();
            // Your code here
            //...
            base.WndProc(ref m);
        }
    }
