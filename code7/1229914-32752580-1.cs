       using (SqlDataAdapter sqlDA = new SqlDataAdapter("Select * from user where username = @username and password = @pass", sqlConnect))
        {
            sqlDA.SelectCommand.CommandType = CommandType.Text;
            sqlDA.SelectCommand.Parameters.Add("@username", SqlDbType.Varchar).Value = username;
    sqlDA.SelectCommand.Parameters.Add("@pass", SqlDbType.Varchar).Value = password;
        
            sqlDA.Fill(dataTableVariable);
            return dataTableVariable;
        }
