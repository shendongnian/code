        static string connString = @"Server=myServerName;Database=myDbName;Trusted_Connection=True;";
        static string fileName = @"C:\CODE\myfile.txt";
    
    	public static void WriteFile(string fileName)
    	{
    		SqlCommand comm = new SqlCommand();
    		comm.Connection = new SqlConnection(connString);
    		String sql = @"select col1, col2 from myTable";
    
    		comm.CommandText = sql;
    		comm.Connection.Open();
    
    		SqlDataReader sqlReader = comm.ExecuteReader();
    
            // Change the Encoding to what you need here (UTF8, Unicode, etc)
    		using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false, Encoding.UTF8))
    		{
    			while (sqlReader.Read())
    			{
    				writer.WriteLine(sqlReader["col1"] + "\t" + sqlReader["col2"]);
    			}
    		}
    
    		sqlReader.Close();
    		comm.Connection.Close();
    	}
