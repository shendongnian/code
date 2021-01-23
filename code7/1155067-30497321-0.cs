    string sql = "INSERT INTO MyTable (Col1, Col2) VALUES (@Value1, @Value2)"; 
    using (MySqlConnection con = new MySqlConnection(connectionString))
    {  
    	int retvalue;
    	con.Open();   
    	foreach (DataRow row in myTable.Rows)   
    	{      
    		MySqlCommand myCommand = new MySqlCommand();
    		myCommand.Connection = con;      
    		myCommand.CommandText = sql;      
    		myCommand.Parameters.AddWithValue("@Value1", r["Value1"]);      
    		myCommand.Parameters.AddWithValue("@Value2", r["Value2"]);      		
    		retvalue = myCommand.ExecuteNonQuery();   
    	}
    }
