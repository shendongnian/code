    <connectionStrings>
      <add name="connString1" connectionString="..." providerName="MySql.Data.MySqlClient"<entityFramework>
      <add name="connString2" connectionString="..." providerName="System.Data.SqlServerCe.4.0"<entityFramework>
    </connectionStrings>
    <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlCeConnectionFactory, EntityFramework">
            <parameters>
              <parameter value="System.Data.SqlServerCe.4.0" />
            </parameters>
        </defaultConnectionFactory>
        <providers>
            <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6" />
            <provider invariantName="System.Data.SqlServerCe.4.0" type="System.Data.Entity.SqlServerCompact.SqlCeProviderServices, EntityFramework.SqlServerCompact" />
         </providers>
    </entityFramework>
