        public Game()
        {
            Results toResults = new Results();
            toResults.FormClosing += F_FormClosing;
        }
        private void F_FormClosing(object sender, FormClosingEventArgs e)
        {
            toResults.Hide();
            e.Cancel = true;
        }
        private void ShowResults()
        {
            toResults.Show();
        }
