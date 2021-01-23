    cmd = new SqlCommand("Select Username FROM [User] WHERE Username =@UsernameValue AND Password =@PasswordValue", loginConn);
    loginConn.Open();
    cmd.CommandType = CommandType.Text;
    cmd.Parameters.Add("@UsernameValue", SqlDbType.VarChar).Value = Main_T_Username.Text;
    cmd2.Parameters.Add("@PasswordValue", SqlDbType.VarChar).Value = Main_T_Password.Text;
