    using (SqlCeConnection  conn = new SqlCeConnection ("Server=.;Database=Northwind;User Id=sa;Password=as"))
    {
    	using (SqlCeCommand  cmd = conn.CreateCommand())
    	{
    		conn.Open();
    		//commands represent a query or a stored procedure       
    		cmd.CommandText = "SELECT buyEURrate FROM CurrencyRates";
    		using (SqlCeDataReader rd = cmd.ExecuteReader())
    		{
    			double rate = 0;
    			if (rd.Read()) // if datareader has rows
    			{
    				rate = Convert.ToDouble(rd[0]);
    			}
    		}
    		conn.Close();
    	}
    }
