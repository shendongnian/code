    SqlConnection conn = new SqlConnection(someValidConnectionString);
    string formName = Utilities.SQLGet<string>(conn, 
        "SELECT [FormName] " + 
        "FROM [SomeTable] WHERE [ClientID] = 1;") // Not considering SQL injection here!
        
