        /// <summary>
        /// Gets the database version.
        /// </summary>
        /// <param name="connectionString">The connection string of database to query.</param>
        /// <param name="tryAzureFirst">Whether we should try the azure server method first.</param>
        /// <returns>DAC pack version</returns>
        internal string GetDatabaseVersion(string connectionString, bool? tryAzureFirst = null)
        {
            bool tryAzure = tryAzureFirst ?? AzureHelper.IsAzure;
            return this.sqlRetryPolicy.ExecuteAction(() =>
            {
                DataContext context = null;
                try
                {
                    var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                    string databaseName = connectionStringBuilder.InitialCatalog;
                    string query = "select type_version from msdb.dbo.sysdac_instances WHERE instance_name = {0}";
                    if (tryAzure)
                    {
                        // On Azure we must be connected to the master database to query sysdac_instances
                        connectionStringBuilder.InitialCatalog = "Master";
                        var conn = new SqlConnection(connectionStringBuilder.ConnectionString);
                        context = new DataContext(conn, mappingSource) { DeferredLoadingEnabled = false };
                        query = "select type_version from master.dbo.sysdac_instances WHERE instance_name = {0}";
                    }
                    else
                    {
                        context = this.CreateContext();
                    }
                    return context.ExecuteQuery<string>(query, databaseName).FirstOrDefault();
                }
                catch (Exception)
                {
                    if (!tryAzureFirst.HasValue)
                    {
                        return this.GetDatabaseVersion(connectionString, !tryAzure);
                    }
                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            });
        }
