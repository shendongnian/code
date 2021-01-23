    private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main ss = new Main(this);
            ss.Show();
            txtboxUser.Text = String.Empty;
            txtboxPass.Text = String.Empty;
        }
