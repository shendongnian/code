        private void GameForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            using (frmAsk frm = new frmAsk())
            {
                frm.ShowDialog();
                LoadGameInfo(frm.LoadNewGame);
            }
            this.Show();
        }
