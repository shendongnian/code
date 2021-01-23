	<configuration>
		<configSections>
			<section name="oracle.manageddataaccess.client" type="OracleInternal.Common.ODPMSectionHandler, Oracle.ManagedDataAccess, Version=4.121.2.0, Culture=neutral, PublicKeyToken=89b483f429c47342" />
		</configSections>
		<connectionStrings>
			<add name="DbContext" connectionString="DATA SOURCE=XXXXX.managed;USER ID=XXXXX;PASSWORD=XXXXXXX;PERSIST SECURITY INFO=True;POOLING=False" providerName="Oracle.ManagedDataAccess.Client" />
		</connectionStrings>
		<runtime>
			<assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
				<dependentAssembly>
					<publisherPolicy apply="no" />
					<assemblyIdentity name="Oracle.ManagedDataAccess" publicKeyToken="89b483f429c47342" culture="neutral" />
				</dependentAssembly>
			</assemblyBinding>
		</runtime>
		
		<!-- add this if you use Entity Framework only -->
		<entityFramework>
			<defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
			<providers>
				<provider invariantName="Oracle.ManagedDataAccess.Client" type="Oracle.ManagedDataAccess.EntityFramework.EFOracleProviderServices, Oracle.ManagedDataAccess.EntityFramework, Version=6.121.2.0, Culture=neutral, PublicKeyToken=89b483f429c47342" />
			</providers>
		</entityFramework>
		<!-- here's the important bit, just copy descriptor from your existing tnsnames.ora file -->
		<oracle.manageddataaccess.client>
			<version number="*">
				<dataSources>
					<dataSource alias="XXXXX.managed" descriptor="(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = XXXXXX.com)(PORT = 999999))(CONNECT_DATA = (SERVICE_NAME = XXXXX)(SERVER = dedicated)))" />
				</dataSources>
			</version>
		</oracle.manageddataaccess.client>
		<system.data>
			<DbProviderFactories>
				<remove invariant="Oracle.ManagedDataAccess.Client" />
				<add name="ODP.NET, Managed Driver" invariant="Oracle.ManagedDataAccess.Client" description="Oracle Data Provider for .NET, Managed Driver" type="Oracle.ManagedDataAccess.Client.OracleClientFactory, Oracle.ManagedDataAccess, Version=4.121.2.0, Culture=neutral, PublicKeyToken=89b483f429c47342" />
			</DbProviderFactories>
		</system.data>
	</configuration>
