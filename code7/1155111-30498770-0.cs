    string sqlConnectionString = "Data Source=localhost;
		 Initial Catalog=AdventureWorks;Integrated Security=True;Connection Timeout=60;multipleactiveresultsets=true"
    string providerName = "System.Data.SqlClient";    
    EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
    
    entityBuilder.Provider = providerName;
    entityBuilder.ProviderConnectionString = sqlConnectionString;
    // Set the Metadata location.
    entityBuilder.Metadata = @"res://*/AdventureWorksModel.csdl|
                            res://*/AdventureWorksModel.ssdl|
                            res://*/AdventureWorksModel.msl";
    string entityConnectionString = entityBuilder.ToString();
