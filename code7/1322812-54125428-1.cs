    public static class SqlQueryExtensions
    {
        public static IList<T> SqlQuery<T>(this DbContext db, string sql, params object[] parameters) where T : class
        {
            using (var db2 = new ContextForQueryType<T>(db.Database.GetDbConnection()))
            {
                return db2.Query<T>().FromSql(sql, parameters).ToList();
            }
        }
        private class ContextForQueryType<T> : DbContext where T : class
        {
            private readonly DbConnection connection;
            public ContextForQueryType(DbConnection connection)
            {
                this.connection = connection;
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // switch on the connection type name to enable support multiple providers
                // var name = con.GetType().Name;
                optionsBuilder.UseSqlServer(connection, options => options.EnableRetryOnFailure());
                base.OnConfiguring(optionsBuilder);
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Query<T>();
                base.OnModelCreating(modelBuilder);
            }
        }
    }
