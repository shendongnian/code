    private readonly string dbConnection = ...;
    private const string validateUserQuery = "...;";
    
    public bool ValidateUser(string user)
    {
         using(var connection = new SqlConnection(dbConnection));
         using(var command = new SqlCommand(validateUserQuery, connection))
         {
              connection.Open();
              command.Parameters.Add("@User", SqlDbType.NVarChar, 50).Value = user;
              var result = command.ExecuteScalar() as string;
    
              if(!string.IsNullOrEmpty(result))
                   return true;
         }
    
         return false;
    }
