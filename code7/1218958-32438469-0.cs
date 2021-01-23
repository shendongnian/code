        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Are you sure to QUIT ?", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                Environment.Exit(0);
            }
            catch
            {
                Environment.Exit(0);
            }
        }
