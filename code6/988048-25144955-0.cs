    ///////////////////////////////////////////////////////////
    // just setup for the context for demo purposes, you would
    // reference this.Database in place of creating context.
    SqlConnection connection = new SqlConnection("Data Source = .; Initial Catalog = MyDb; Integrated Security = SSPI;");
    var dataContext = new System.Data.Linq.DataContext(connection);
    ///////////////////////////////////////////////////////////
    
    string updateQuery = "UPDATE TOP (@p1) dbo.Foo " +
    "SET Data = @p2 " +
    "WHERE Data IS NULL";
    
    dataContext.Connection.Open();
    
    var command = dataContext.Connection.CreateCommand();
    command.CommandText = updateQuery;
    command.CommandType = System.Data.CommandType.Text;
    
    var param1 = new SqlParameter("@p1", System.Data.SqlDbType.Int);   
    param1.Value = 3;
    command.Parameters.Add(param1);
    
    var param2 = new SqlParameter("@p2", System.Data.SqlDbType.Int);
    param2.Value = 1;
    command.Parameters.Add(param2);
    command.Prepare();
    command.ExecuteNonQuery();
    param2.Value = 5;
    command.ExecuteNonQuery();
