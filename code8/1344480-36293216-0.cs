    using (OleDbConnection conn = new OleDbConnection())
    {
    	conn.ConnectionString = connection.dbdataSource;
    	conn.Open();
    	
    	foreach (var listBoxItem in ServicePartsList.Items)
    	{
    		item = listBoxItem.ToString();
    		string[] result = item.Split(',');
    		MessageBox.Show(result[0] + result[1]);
    		// insert into database
    		using (OleDbCommand addPart = new OleDbCommand())
    		{
    			//Open Connection
    			
    			addPart.Connection = conn;
    
    			addPart.CommandText = "INSERT INTO servicePart (ServiceID, PartNo, Quantity) VALUES (@sID, " + "@partNo, " + "@quantity)";
    			addPart.Parameters.AddWithValue("sID", ModelCode + ModelYear + ButtonClick);
    			addPart.Parameters.AddWithValue("partNo", result[0]);
    			addPart.Parameters.AddWithValue("quantity", result[1]);
    
    			//execute SQL
    			int recordsAdded = addPart.ExecuteNonQuery();
    
    		}
    	}
    	//Close DB Connection
    	conn.Close();
    }
