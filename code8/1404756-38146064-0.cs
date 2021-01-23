    using (var sc = new SqlConnection("Data Source=ACER;Initial Catalog=BonTempsDB;Integrated Security=True"))
    {
    	using (var com = new SqlCommand("sql cmd text", sc))
    	{
    		try
    		{
    			sc.Open();
    			com.ExecuteNonQuery();
    		}
    		catch
    		{
    			
    		}
    	}
    }
