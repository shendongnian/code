    string sql = @"SELECT COUNT(*) FROM Login 
                   WHERE Username = @UserName AND Password = @Password";
    using(var LoginConnect = new SqlDataAdapter(sql, LoginConnection))
    {
        var selectParameters = LoginConnect.SelectCommand.Parameters;
        selectParameters.Add("@UserName", SqlDbType.VarChar).Value = txtUsername.Text;
        selectParameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text;
        LoginConnect.Fill(dt);
    }
