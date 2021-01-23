    string sql = "SELECT user, pass FROM users WHERE user=@username and pass=@password";
    MySqlCommand cmd = new MySqlCommand(sql, conn);
    string username1 = textUser.Text;
    string password1 = txt_passwordBox.Password;
    cmd.Parameters.Add(new SqlParameter("@username", username1));
    cmd.Parameters.Add(new SqlParameter("@password", password1));
