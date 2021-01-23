        private void pwd_TextChanged(object sender, EventArgs e)
        {
            if (pwd.Text == "enter password")
                pwd.PasswordChar = Convert.ToChar(0);
            else if (pwd.Text == "")
                pwd.Text = "enter password";
            else
               pwd.PasswordChar = '*'; 
        }
