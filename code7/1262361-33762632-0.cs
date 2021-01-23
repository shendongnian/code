    public class DivAppsDataContext : DbContext
    {
        public DivAppsDataContext() : base("name=MyConnectionString")
        {
        }
    
        public DbSet<Account> Accounts{ get; set; }
    }
    <configuration>
      <connectionStrings>
        <add name="MyConnectionString" connectionString="Data Source=.;Initial Catalog=Whatever;Integrated Security=true"/>
      </connectionStrings>
      <configSections>
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=xxxxxx" requirePermission="false" />
      </configSections>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        </providers>
      </entityFramework>
    </configuration>
