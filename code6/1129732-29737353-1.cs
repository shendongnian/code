    private readonly string dbConnection = ConfigurationManager.ConnectionStrings["..."].ConnectionString;
    private const string query = "SELECT * FROM [Example] WHERE ([Id] = @Id);";
    
    public void Example()
    {
         using(var connection = new OleDbConnection(dbConnection))
             using(var command = new OleDbCommand(query, connection))
             {
                  // Apply parameter, open connection, etc.
             }
    }
