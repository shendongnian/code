 I usually prefer to configure the initializer database within EntityFramework configuration section on web.config file, for example:
    <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <contexts>
          <context type="MyAssembly.Fullname.EedezDbContext, MyAssembly.Fullname">
            <databaseInitializer type="System.Data.Entity.MigrateDatabaseToLatestVersion`2[[MyAssembly.Fullname.EedezDbContext, MyAssembly.Fullname], [MyAssembly.Fullname.Configuration, MyAssembly.Fullname ]], EntityFramework" />
          </context>
        </contexts>
    </entityFramework>
