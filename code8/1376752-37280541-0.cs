    <configuration>
         
      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
      </configSections>
    
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        </providers>
      </entityFramework>
    
      <connectionStrings>
        <add name="testEntities" connectionString="metadata=res://*/Models.MyModel.csdl|res://*/Models.MyModel.ssdl|res://*/Models.MyModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=data source=MyLocalServer/sqlexpress;initial catalog=test;persist security info=True;user id=xxxxxx;password=xxxxxxx;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
      /connectionStrings>
    
    </configuration>
