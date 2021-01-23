    class AutoClosingMessageBox
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        static DialogResult? dialogResult_ = null;
        private AutoClosingMessageBox(string text, string caption, int timeout, MessageBoxButtons msbb)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            dialogResult_ = MessageBox.Show(text, caption, msbb);
        }
        public static DialogResult? Show(string text, string caption, int timeout, MessageBoxButtons efb)
        {
            new AutoClosingMessageBox(text, caption, timeout, efb);
            return dialogResult_;
        }
        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption);
            if (mbWnd != IntPtr.Zero)
            {
                SetForegroundWindow(mbWnd);
                SendKeys.SendWait("%I");
                _timeoutTimer.Dispose();
            }
            dialogResult_ = null;
        }
        [DllImport("user32.dll", SetLastError = true)]
        extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        extern static IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        extern static bool SetForegroundWindow(IntPtr hwnd);
    }
