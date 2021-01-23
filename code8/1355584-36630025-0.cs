    using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection())
    {
    	connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Etay\Documents\Visual Studio 2012\WebSites\Josef\Shared\users.mdb";
    	using (System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand())
    	{
    		command.Connection = connection;
    		command.CommandText = "INSERT INTO users (userName,passWord,Uname,pic) VALUES (@userName,@passWord,@uname,@pic)";
    		command.Parameters.AddWithValue("@userName", userName);
    		command.Parameters.AddWithValue("@password", pass);
    		command.Parameters.AddWithValue("@Uname", Uname);
    		command.Parameters.AddWithValue("@pic", pic);
    
    		connection.Open();
    		command.ExecuteNonQuery();
    	}
    }
