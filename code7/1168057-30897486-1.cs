        private void button1_Click(object sender, EventArgs e) {
            button1.Enabled = false;
            button1.Update();
            '' long running code
            ''...
            Application.DoEvents();
            if (!button1.IsDisposed) button1.Enabled = true;
        }
