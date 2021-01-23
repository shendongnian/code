     Try this code 
        
     
    
      string SearchQuery = String.Format(@"if exists (select * from table where  colName = '{0}') select 1 else select 0", "123");    AseConnection connection = new AseConnection();
        connection.ConnectionString = connectionString;
        connection.Open();
        try
        {
            AseCommand selectCommand = new AseCommand(SearchQuery, connection);
        	        int doesValExist = (int)selectCommand.ExecuteScalar();
        }
        catch(Exception ex)
        {
        
        }
