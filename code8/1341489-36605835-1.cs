    //Get our connection string setting, and the connectionString it contains
    ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["Program.Properties.Settings.InventoryDBConnectionString"];
    String connectionString = cs.ConnectionString;
    //Open a connection to the database
    OleDbConnection con = new OleDbConnection(connectionString);
