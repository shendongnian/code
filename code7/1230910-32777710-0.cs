        if (dr1.Read())
    {
        string dr = dr1[2].ToString();
        if (dr == "1")
        {
            Form1 fm = new Form1();
            fm.Show();
            this.hide();
        }
    }
    private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
