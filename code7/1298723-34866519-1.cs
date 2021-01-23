    string selectedEnvironemntName = "Development"; //set from dropdown selection
    var predefinedConnections = ConfigurationManager.ConnectionStrings;
    SqlConnectionStringBuilder connStringBuilder = null;
    
    foreach( ConnectionStringSettings connString in predefinedConnections)
    {
        if (connString.Name == selectedEnvironemntName )
        {
            connStringBuilder = new SqlConnectionStringBuilder(connString.ConnectionString);
        }
    }
    //the below two lines can be anywhere in your solution as long as you can pass the connStringBuilder to SqlConnection definition
    SqlConnection connection = new SqlConnection();
    connection.ConnectionString = connStringBuilder.ConnectionString;
