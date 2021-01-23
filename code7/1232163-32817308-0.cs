            <connectionStrings>
                <add name="MyContext" providerName="MySql.Data.MySqlClient" 
                    connectionString="server=localhost;port=3306;database=mycontext;uid=root;password=********"/>
            </connectionStrings>
            <entityFramework>
                <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework"/>
                <providers>
                    <provider invariantName="MySql.Data.MySqlClient" 
                        type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6"/>
                    <provider invariantName="System.Data.SqlClient" 
                        type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer"/>
                </providers>
            </entityFramework>
