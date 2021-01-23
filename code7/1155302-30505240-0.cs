                var sqlCsBuilder = new SqlConnectionStringBuilder(ecsBuilder.ProviderConnectionString)
                {
                    InitialCatalog = dbName,
                    UserID=userId,
                    DataSource=host,
                    Password=password
                };
                 var providerConnectionString = sqlCsBuilder.ToString();
                
                ecsBuilder.ProviderConnectionString = providerConnectionString;
                string contextConnectionString = ecsBuilder.ToString();
                using (var db = new DbContext(contextConnectionString))
                {
                    OWordpressContainer objContext = new OWordpressContainer(contextConnectionString);
                    var optionEntity = new Options();
                    optionEntity.key = "DBInfo";
                    optionEntity.value = "{userId:" + userId + "',password:'" + password + "',host:'" + host + "',dbName:'" + dbName + "'}";
                    objContext.Options.Add(optionEntity);
                    objContext.SaveChanges();
                }
