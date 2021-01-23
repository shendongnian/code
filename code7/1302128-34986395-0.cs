    <configuration>
      <configSections>
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
      </configSections>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
      </startup>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
          <parameters>
            <parameter value="mssqllocaldb" />
          </parameters>
        </defaultConnectionFactory>
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
          <provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6" />
        </providers>
      </entityFramework>
      <system.data>
        <DbProviderFactories>
          <remove invariant="System.Data.SQLite" />
          <add name="SQLite Data Provider" invariant="System.Data.SQLite" description="Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite" />
        </DbProviderFactories>
      </system.data>
      <connectionStrings>
        <add name="AccountHelperEntities" connectionString="metadata=res://*/AccountHelperModel.csdl|res://*/AccountHelperModel.ssdl|res://*/AccountHelperModel.msl;provider=System.Data.SQLite;provider connection string='data source=&quot;W:\visual studio projects\AccountHelper\AccountHelper\Data\AccountHelper.sqlite3&quot;'" providerName="System.Data.EntityClient" />
      </connectionStrings>
    </configuration>
