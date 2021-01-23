    using(OracleCommand cmd = new OracleCommand("select user_name,parameter_name,parameter_value from table1 where user_name ='USER'", ocConnection))
    {
    	cmd.CommandType = CommandType.Text;
    	using(OracleDataReader dr = cmd.ExecuteReader())
    	{
            // check column names for debugging purposes
            var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
    		while (dr.Read())
    		{
    			if (dr["PARAMETER_NAME"].ToString() =="NAME1")
    			{
    				class1.Value1 = Convert.ToInt32(dr["PARAMETER_VALUE"].ToString());
    			}
    
    			if ((dr["PARAMETER_NAME"].ToString()) == "NAME2")
    			{
    				class1.Value2 = Convert.ToInt32(dr["PARAMETER_VALUE"].ToString());
    			}
    		}
    	}
    }
