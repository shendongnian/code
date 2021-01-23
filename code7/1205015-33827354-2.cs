    public sealed class DatabaseMigrationsConfiguration : DbMigrationsConfiguration<DatabaseContext>
    {
        public DatabaseMigrationsConfiguration()
        {
            SetSqlGenerator("System.Data.SqlClient", new MigrationScriptBuilder());
        }
    }
