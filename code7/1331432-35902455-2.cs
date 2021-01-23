    using(var conn = new SqlConnection(<connection string here>))
    {
    	try
    	{
    		conn.Open();
    		string sql = "insert into [table_name] values (@column1Value,@column2Value,...);";
    		using(var cmd = new SqlCommand(sql,conn))
    		{
                cmd.Parameters.AddWithValue("@column1Value",1);//Presuming column 1 is an int
                cmd.Parameters.AddWithValue("@column2Value","Smith"); //Presuming column 2 is a varchar (string)
    			cmd.ExecuteNonQuery();
    		}
    	}
    	catch (Exception ex)
    	{
    		string err = ex.Message;
    	}
    }
