    public sealed class Configuration : DbMigrationsConfiguration<Sistema.DataAccess.SistemaContext>
        {
            public Configuration()
            {
                DbConfiguration.SetConfiguration(new DbConfigurationBase("MYSQL"));
    
                DbInterception.Add(new NLogCommandInterceptor());// guardar logs
    
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true; 
    
                SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());//Mysql da erro se nao colocar isso.(Pelo que vi da para colocar no App.config tambem.)
                SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySQLHistoryContext(conn, schema));
            }
    }
