        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd,
            int X, int Y, int nWidth, int nHeight, bool bRepaint);
        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) {
                Hide();
                if (!MoveWindow(Handle, Screen.PrimaryScreen.WorkingArea.Left
                        + Screen.PrimaryScreen.WorkingArea.Width - Width,
                        Top, Width, Height, false))
                    throw new Win32Exception();
            }
        }
        private void notifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (WindowState == FormWindowState.Minimized || !timer.Enabled) {
                    Show();
                    WindowState = FormWindowState.Normal;
                    Activate();
                }
                else 
                    WindowState = FormWindowState.Minimized;
        }
        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
        }
