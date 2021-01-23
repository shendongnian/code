    public sealed class Configuration2 : DbMigrationsConfiguration<Sistema.DataAccess.SistemaContext2>
        {
            public Configuration2()
            {
                DbConfiguration.SetConfiguration(new DbConfigurationBase("SQLCE"));
    
                DbInterception.Add(new NLogCommandInterceptor());// guardar logs
    
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
            }
    }
