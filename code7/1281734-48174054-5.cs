    public static string GetEntityConnectionString(string connectionString)
        {
            var entityBuilder = new EntityConnectionStringBuilder();
            // WARNING
            // Check app config and set the appropriate DBModel
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = connectionString + ";MultipleActiveResultSets=True;App=EntityFramework;";
            entityBuilder.Metadata = @"res://*/DBModel.CWDB.csdl|res://*/DBModel.CWDB.ssdl|res://*/DBModel.CWDB.msl";
            return entityBuilder.ToString();
        }
