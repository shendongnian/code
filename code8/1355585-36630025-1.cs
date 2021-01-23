    using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection())
    {
    	connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Etay\Documents\Visual Studio 2012\WebSites\Josef\Shared\users.mdb";
    	using (System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand())
    	{
    		command.Connection = connection;
    		command.CommandText = "INSERT INTO users (userName,passWord,Uname,pic) VALUES (?,?,?,?)";
    		command.Parameters.Add(userName);
    		command.Parameters.Add(pass);
    		command.Parameters.Add(Uname);
    		command.Parameters.Add(pic);
    
    		connection.Open();
    		command.ExecuteNonQuery();
    	}
    }
