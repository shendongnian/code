    System.Data.SqlClient.SqlConnectionStringBuilder builder =
      new System.Data.SqlClient.SqlConnectionStringBuilder();
    builder["Data Source"] = "123.456.789.012";
    builder["Initial Catalog"] = "DiscoverThePlanet";
    builder["User ID"] = "TestUser";
    builder["Password"] = "Test";
    Console.WriteLine(builder.ConnectionString);
