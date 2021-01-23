    public void login()
        {
            Connect();
            Login lg = this.lg;
            string username = lg.Username;
            string password = lg.Password;
            MessageBox.Show(username + "\n" + password);
        }
    private void button1_Click(object sender, EventArgs e)
        {
            login();
        }
