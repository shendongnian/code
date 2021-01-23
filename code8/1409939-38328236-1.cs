    public class BaseEfConfiguration : DbConfigurationTypeAttribute
    {
        public BaseEfConfiguration() : base(SqlConfiguration)
        {
        }
        public static Type SqlConfiguration
        {
            get
            {
                string databaseTypeName = ConfigurationManager.AppSettings["DatabaseType"];
                switch (databaseTypeName)
                {
                    case "MySQL":
                        return typeof(MySqlEFConfiguration);
                    case "MSSQL":
                        return typeof(MsSqlEFConfiguration);
                    default:
                        throw new NotImplementedException($"No such SQL configuration type {databaseTypeName}");
                }
            }
        }
    }
    [BaseEfConfiguration]
    public class BaseDbContext : DbContext
    {
    }
