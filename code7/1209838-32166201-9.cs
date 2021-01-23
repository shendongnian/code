    public string updateQuery = "UPDATE tbl_test SET name=@name,surname=@surname,phone=@phone,address=@address,date=@date WHERE id=@id ";
    
    // ...
    
    conn = new SqlConnection(connStr);
    try
    {
    	string[] importfiles = Directory.GetFiles(@"C:\Users\An\Desktop\", "test.txt");
    
    	using (conn)
    	{
    		using (cmd = new SqlCommand(updateQuery, conn))
    		{
    
    			cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50);
    			cmd.Parameters.Add("@surname", SqlDbType.NVarChar, 50);
    			cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 50);
    			cmd.Parameters.Add("@address", SqlDbType.NVarChar, 200);
    			cmd.Parameters.Add("@date", SqlDbType.DateTime);
    			cmd.Parameters.Add("@id", SqlDbType.Int);
    
    			foreach (string importfile in importfiles)
    			{
    				string[] allLines = File.ReadAllLines(importfile);
    				conn.Open();
    
    				for (int index = 0; index < allLines.Length; index++)
    				{
    					string[] items = allLines[index].Split(new[] { '|' })
    						.Select(i => i
    						.Split(new[] { '=' })[1])
    						.ToArray();
    
    					cmd.Parameters["@name"].Value = items[0];
    					cmd.Parameters["@surname"].Value = items[1];
    					cmd.Parameters["@phone"].Value = items[2];
    					cmd.Parameters["@address"].Value = items[3];
    					cmd.Parameters["@date"].Value = items[4];
    					cmd.ExecuteNonQuery();
    				}
    				conn.Close();
    			}
    
    		}
    	}
    }
