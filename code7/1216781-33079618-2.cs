            public static string CreateConnStr(string dataSource, string instanceName, string userName, string password)
            {
                string connectionString = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder
                {
                    Metadata = "res://*/ExampleModel.csdl|res://*/ExampleModel.ssdl|res://*/ExampleModel.msl",
                    Provider = "System.Data.SqlClient",
                    ProviderConnectionString = new System.Data.SqlClient.SqlConnectionStringBuilder
                    {
                        InitialCatalog = instanceName,
                        DataSource = dataSource,
                        IntegratedSecurity = false,
                        UserID = userName,
                        Password = password,              
                    }.ConnectionString
                }.ConnectionString;
    
                return connectionString;
            }
