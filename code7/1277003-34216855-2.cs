        public test1Entities()
             : base(nameOrConnectionString: ConnectionString())
        {
        }
        private static string ConnectionString()
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = "DEV-4";
            sqlBuilder.InitialCatalog = "test1";
            sqlBuilder.PersistSecurityInfo = true;
            sqlBuilder.IntegratedSecurity = true;
            sqlBuilder.MultipleActiveResultSets = true;
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
            entityBuilder.Metadata = "res://*/";
            entityBuilder.Provider = "System.Data.SqlClient";
            return entityBuilder.ToString();
        }
