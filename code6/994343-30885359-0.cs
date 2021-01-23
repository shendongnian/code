    public static void CSVToMySQL()
    {
    	string ConnectionString = "server=192.168.1xxx";
    	string Command = "INSERT INTO User (FirstName, LastName ) VALUES (@FirstName, @LastName);";
    	using (MySqlConnection mConnection = new MySqlConnection(ConnectionString)) 
    	{
    		mConnection.Open();
    		using (MySqlTransaction trans = mConnection.BeginTransaction()) 
    		{
    			using (MySqlCommand myCmd = new MySqlCommand(Command, mConnection, trans)) 
    			{
    				myCmd.CommandType = CommandType.Text;
    				for (int i = 0; i <= 99999; i++) 
    				{
    					//inserting 100k items
    					myCmd.Parameters.Clear();
    					myCmd.Parameters.AddWithValue("@FirstName", "test");
    					myCmd.Parameters.AddWithValue("@LastName", "test");
    					myCmd.ExecuteNonQuery();
    				}
    				trans.Commit();
    			}
    		}
    	}
    }
