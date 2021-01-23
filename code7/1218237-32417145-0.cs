    using (var connection = new OleDbConnection(cs))
    using (var comm = new connection.CreateCommand())
    {
        comm.CommandText = @"INSERT INTO [User]([User_Name],[User_Password],[Entry_Date],[Entry_Time]) 
                             VALUES (@val1,@val2,@val3,@val4)"
        comm.Parameters.Add("@val1", txtUserName.Text);
        comm.Parameters.Add("@val2", txtPassword.Text);
        comm.Parameters.Add("@val3", DateTime.Now.Date);
        comm.Parameters.Add("@val4", DateTime.Now.TimeOfDay);
        connection.Open();
        comm.ExecuteNonQuery();
    }
