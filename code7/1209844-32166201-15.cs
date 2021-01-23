    **public string selectQuery= "Select * FROM tbl_test" ; 
    conn = new SqlConnection(connStr);
    try
    {
    	using (conn)
    	{
    		using (cmd = new SqlCommand(selectQuery, conn))
    		{
    			using(var dataReader = cmd.ExecuteReader())
                {
                    while(datareader.reader())
                    {
                         //Read the datareader for values and set them .
                         var id = datareader.GetInt32(0);
                    }
                }
    		}
    	}
    }**
