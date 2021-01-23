    SqlConnection con = new SqlConnection();
    var conString = @"Data Source = .\SQLEXPRESS; Initial Catalog=dbName; Integrated Security = true";
    con.ConnectionString = conString;
    
    try
    {
         con.Open();
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
