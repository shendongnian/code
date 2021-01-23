    partial class Entities : DbContext
    {
        private static string BuildConnectionString 
        {
            get
            {
                // Specify the provider name, server and database.
                string providerName = "System.Data.SqlClient";
                string serverName = DatabaseController.Server;
                string databaseName = <DatabaseName>;
                // Initialize the connection string builder for the
                // underlying provider.
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                // Set the properties for the data source.
                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                sqlBuilder.UserID = <user>;
                sqlBuilder.Password = <password>;
                sqlBuilder.IntegratedSecurity = false;
                sqlBuilder.PersistSecurityInfo = true;
                sqlBuilder.MultipleActiveResultSets = true;
                // Build the SqlConnection connection string.
                string providerString = sqlBuilder.ToString();
                // Initialize the EntityConnectionStringBuilder.
                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
                //Set the provider name.
                entityBuilder.Provider = providerName;
                // Set the provider-specific connection string.
                entityBuilder.ProviderConnectionString = providerString;
                //assembly full name
                Type t = typeof(Entities);
                string assemblyFullName = t.Assembly.FullName.ToString();
                // Set the Metadata location.
                entityBuilder.Metadata = string.Format("res://{0}/", //Models.Model.csdl|Models.Model.ssdl|Models.Model.msl", 
                    assemblyFullName);
                try
                {
                    //Test de conexion
                    using (EntityConnection conn = new EntityConnection(entityBuilder.ToString()))
                    {
                        conn.Open();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Connection error" + ex.Message);
                }
                return entityBuilder.ToString();
            }
        }
