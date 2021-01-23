    public void Login()
        {
        //Admin login temp
        if (txtusername.Text == "admin" && txtpassword.Text == "admin123")
        {
            Form mainmenu = new frmmainmenu();
            Useraccounts.LoggedInUsername = txtusername.Text;
            this.Hide();
            mainmenu.Show();
            return; <----**delete this return** 
