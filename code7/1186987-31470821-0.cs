        public Process p = new Process();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        private void Preview_Button_Click(object sender, EventArgs e)
        {
            p = Process.Start("calc.exe");
            Thread.Sleep(500);
            p.WaitForInputIdle();
            SetParent(p.MainWindowHandle, ViewingScreen_PictureBox.Handle);
            MoveWindow(p.MainWindowHandle, 0, 0, 230, 320, true);
        }
