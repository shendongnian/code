    private readonly string dbConnection = ConfigurationManager.ConnectionString[".."].ConnectionString;
    private const string queryInsertUser = "INSERT INTO [User] ([FirstName]) VALUES (@FirstName);"
    
    protected void SaveUser(string firstName)
    {
         using(var connection = new SqlConnection(dbConnection))
         using(var command = new SqlCommand(queryInsertUser, connection))
         {
              connection.Open();
              command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = first;
              command.ExecuteNonQuery();
         }
    }
