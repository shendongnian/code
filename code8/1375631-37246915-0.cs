        public override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isClosed == false)
            {
                e.Cancel = true;
                base.OnFormClosing(e);
                Hide();
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                Application.Exit();
            }
        }
