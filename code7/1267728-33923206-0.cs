    class TouchKeyboardProvider
    {
        #region Private: Fields
        private readonly string _virtualKeyboardPath;
        #endregion
        #region ITouchKeyboardProvider Methods
        public TouchKeyboardProvider()
        {
            _virtualKeyboardPath = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles),
                @"Microsoft Shared\ink\TabTip.exe");
            if (!System.IO.File.Exists(_virtualKeyboardPath))
            {
                _virtualKeyboardPath = _virtualKeyboardPath.Replace(" (x86)", string.Empty);
            }
        }
        public void ShowTouchKeyboard()
        {
            try
            {
                Process.Start(_virtualKeyboardPath);
            }
            catch (Exception ex)
            {
                // TODO: Log error.
                Debug.WriteLine(ex.ToString());
            }
        }
        public void HideTouchKeyboard()
        {
            var nullIntPtr = new IntPtr(0);
            const uint wmSyscommand = 0x0112;
            var scClose = new IntPtr(0xF060);
            var keyboardWnd = FindWindow("IPTip_Main_Window", null);
            if (keyboardWnd != nullIntPtr)
            {
                SendMessage(keyboardWnd, wmSyscommand, scClose, nullIntPtr);
            }
        }
        #endregion
        #region Private: Win32 API Methods
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string sClassName, string sAppName);
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);
        #endregion
    }
