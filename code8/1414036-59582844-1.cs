    <?xml version="1.0" encoding="utf-8"?>
	<configuration>
	  <configSections>
		<section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
	  </configSections>
	  <startup>
		<supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
	  </startup>
	  <connectionStrings>
		<add name="context" providerName="MySql.Data.MySqlClient" connectionString="" />
	  </connectionStrings>
	  <entityFramework>
		<defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework"/>
		<providers>
		  <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
		  <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6, Version=6.10.9.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" />
		</providers>
	  </entityFramework>
	</configuration>
