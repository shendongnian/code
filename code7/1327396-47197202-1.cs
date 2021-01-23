    internal sealed class MyConfiguration : DbMigrationsConfiguration<MyDbContext>
    {
        private string firebirdProviderInvariantName = "FirebirdSql.Data.FirebirdClient";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public MyConfiguration()
        {
            SetSqlGenerator(firebirdProviderInvariantName, new FirebirdSqlGenerator();
        }
    }
