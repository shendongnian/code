    public class DbConfigurationBase : DbConfiguration
        {
            public DbConfigurationBase(string value)
            {
                if (value == "MYSQL")
                {
                    //<add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" description=".Net Framework Data Provider for MySQL" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.8.3.0" />
                    string invariantname = MySql.Data.Entity.MySqlProviderInvariantName.ProviderName;//MySql.Data.MySqlClient
                    SetProviderFactory(invariantname, new MySql.Data.MySqlClient.MySqlClientFactory());
                    SetProviderServices(invariantname, new MySql.Data.MySqlClient.MySqlProviderServices());
                    SetDefaultConnectionFactory(new MySql.Data.Entity.MySqlConnectionFactory());
                }
                else if(value == "SQLCE")
                {
                    //NEED TO BE UPDATED HERE
                    //<add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" description=".Net Framework Data Provider for MySQL" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.8.3.0" />
                    /*string invariantname = System.Data.SqlServerCe.;//MySql.Data.MySqlClient
                    SetProviderFactory(invariantname, new MySql.Data.MySqlClient.MySqlClientFactory());
                    SetProviderServices(invariantname, new MySql.Data.MySqlClient.MySqlProviderServices());
                    SetDefaultConnectionFactory(new MySql.Data.Entity.MySqlConnectionFactory());*/
                }
            }
        }
