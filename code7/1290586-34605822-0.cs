        `private static OleDbConnection GetConnection() throws SQLException{
            { 
        if (conn==null) 
    { 
                try{                                                                                    OleDbConnection conn = new OleDbConnection();
                String connectionString = @"Provider=Microsoft.JET.OlEDB.4.0;"
                                          + @"Data Source= C:\Temp\F1\Docs\Expeditors Project\Table1.accbd";
                conn = new OleDbConnection(connectionString);
                conn.Open();
        
                return conn;
            }}
        catch(Exception e){
        e.printStackTrace();
        }
