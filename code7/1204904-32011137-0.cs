    string Command = "SELECT Id FROM User WHERE Username = @Username AND Password = @Password;";
    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
    {
        myConnection.Open();
        using (SqlCommand myCommand = new SqlCommand(Command, myConnection))
        {
            myCommand.Parameters.Add("@Username", tbUser.Text);
            myCommand.Parameters.Add("@Password", tbPass.Text);
            return myCommand.ExecuteScalar() != null;
        }
    }
