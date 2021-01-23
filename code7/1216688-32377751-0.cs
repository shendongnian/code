    //Work with existing connection...
    tableAdapter1.Connection.Close();
    tableAdapter1.Connection.ConnectionString = "Your new DB connection string";
    tableAdapter1.Connection.Open();
    //Work with same adapter but now pointing to new DB specified in above string.
