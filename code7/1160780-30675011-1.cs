    using (SqlConnection connection = new SqlConnection(SQLConnectionString))
    {
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
    
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = @"INSERT INTO [myfriends] ([Friend], [Age]) VALUES ( @hisname, @hisage)";
    	command.Parameters.Add("@hisname", SqlDbType.VarChar, 10).Value =  hisname;
    	command.Parameters.Add("@hisage", SqlDbType.Int).Value =  hisage;
        connection.Open();
        
        command.ExecuteNonQuery();
    }
