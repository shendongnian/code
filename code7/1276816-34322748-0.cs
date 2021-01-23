    protected void PopulateTestGrids()
    {
    	DataSet ds = new DataSet();
    	ds = RunStoredProc();
    	DataTable tableA = ds.Tables[0];
    	DataTable tableB = ds.Tables[1];
    	GridView21.DataSource = tableA;
    	GridView21.DataBind();
    	GridView31.DataSource = tableB;
    	GridView31.DataBind();
    }
    
    public DataSet RunStoredProc(string databaseConnection)
    {
        ds = new DataSet();  
        DSqlQueryBuilder = new StringBuilder();
        SqlQueryBuilder.Append("exec dbo.StoredProc "); 
        ds = ExecuteSqlQuery(databaseConnection, SqlQueryBuilder.ToString());
        return ds;
    }
    
    public DataSet ExecuteSqlQuery(string databaseConnection, string sql)
    {
    	try
    	{
    		System.Configuration.ConnectionStringSettings connstring = System.Configuration.ConfigurationManager.ConnectionStrings["abcddb"];
    		using (SqlConnection conn = new SqlConnection(connstring.ConnectionString))
    		{
    			using (SqlCommand cmd = new SqlCommand())
    			{
    				cmd.CommandText = sqlQuery;
    				cmd.Connection = conn;
    				cmd.CommandType = CommandType.StoredProcedure;
    				conn.Open();
    				SqlDataAdapter adapter = new SqlDataAdapter(cmd);                    
    				adapter.Fill(_dataSet);
    				conn.Close();
    			}                
    		}
    		return _dataSet;
    	}
    	catch (Exception exception) { throw exception; }
    }
