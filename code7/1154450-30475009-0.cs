    var scsb = new SqlConnectionStringBuilder();
    scsb.DataSource = datasource;
    scsb.InitialCatalog = initialCatalogue;
    scsb.IntegratedSecurity = true;
    
    //You also really should wrap your connections in using statements too.
    using(SqlConnection connection = new SqlConnection(scsb.ConnectionString))
    {
        connection.Open();
        //...
    }
