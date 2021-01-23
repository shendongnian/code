        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                Hide();
        }
        private void notifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (WindowState == FormWindowState.Minimized || !timer.Enabled) {
                    Show();
                    WindowState = FormWindowState.Normal;
                    Activate();
                }
                else {
                    Hide();
                    WindowState = FormWindowState.Minimized;
                }
        }
        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
        }
