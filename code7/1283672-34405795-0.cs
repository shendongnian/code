    var sqlBuilder = new SqlConnectionStringBuilder();
    
    // Set the properties for the data source.
    sqlBuilder.DataSource = "ServerName";
    sqlBuilder.InitialCatalog = "DatabaseName";
    sqlBuilder.UserID = "USERNAME";
    sqlBuilder.Password = "PASSWORD";
    sqlBuilder.IntegratedSecurity = true;
    
    // Build the SqlConnection connection string.
    string providerString = sqlBuilder.ToString();
    
    // Initialize the EntityConnectionStringBuilder.
    var entityBuilder = new EntityConnectionStringBuilder();
    
    //Set the provider name.
    entityBuilder.Provider = "System.Data.SqlClient";
    
    // Set the provider-specific connection string.
    entityBuilder.ProviderConnectionString = providerString;
