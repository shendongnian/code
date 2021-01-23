    // Code that tries to load a specific row from "foo"
    // The only change from above is the "ToString()" method called on PhysicalAddress
    var query = "SELECT * FROM foo WHERE macaddress = :macAddress";
    var queryParams = new DynamicParameters();
    queryParams.Add("macAddress", PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF").ToString());
    IDbConnection connection = new NpgsqlConnection(connectionString);
    var foos = connection.Query<foo>(query, queryParams);
