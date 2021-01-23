     [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        private static void CloseDialog()
        {
            var handle = FindWindow(null, "Give your window caption/title here");
            SetForegroundWindow(handle);
    //send alt+f4 using sendkeys method
            System.Windows.Forms.SendKeys.SendWait("%{F4}");
        }
