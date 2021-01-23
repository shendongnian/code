    //Open the connection to your database (using MS SQL as an example)
    SqlConnection connection = new SqlConnection(connectionString)
    //Issue the SQL query to read the data
    string queryString = "SELECT MyTimeStamp, MyNetworkUsage FROM XXX;";
    SqlCommand cmd = new SqlCommand(queryString, connection);
    SqlDataReader reader = command.ExecuteReader();
    //Convert to arrays
    ChartDirector.DBTable table = new ChartDirector.DBTable(reader);
    DateTime[] timeStamps = table.getColAsDateTime(0);  //1st column is timestamp
    double[] data = table.getCol(1);  //2nd column is data
