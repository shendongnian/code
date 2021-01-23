        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Press Yes to Hide only the Form?", "Exit", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                e.Cancel = true;
                timer1.Enabled = true;
                Hide();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Show();
            timer1.Enabled = false;
        }
