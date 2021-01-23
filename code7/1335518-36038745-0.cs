    	protected override IDbConnection OpenConnection()
    	{
    		string cs = "Data Source=dbora1;Max Pool Size=50;Min Pool Size=1;Connection Lifetime=120;Enlist=true;User Id=slu;Password=slu_4d332";;
    		OracleConnection connection = new OracleConnection(cs);
    		try{
    		connection.Open();
    			}catch(Exception ex)
    			{					
    				ex.ToString();
    			}
    
    		return connection;
    	}
    
    	#endregion
    }
