    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        <!-- More stuff here for my app in particular . . . -->
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
      </configSections>
      <connectionStrings>
        <remove name="SQLiteConnection" />
        <remove name="EntitiesConnection" />
        <add name="SQLiteConnection" connectionString=". . ." />
        <add name="EntitiesConnection" connectionString=". . ." />
      </connectionStrings>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0" />
      </startup>
      <system.data>
        <!--
            NOTE: The extra "remove" element below is to prevent the design-time
                  support components within EF6 from selecting the legacy ADO.NET
                  provider for SQLite (i.e. the one without any EF6 support).  It
                  appears to only consider the first ADO.NET provider in the list
                  within the resulting "app.config" or "web.config" file.
        -->
		<DbProviderFactories>
			<remove invariant="System.Data.SQLite" />
			<add invariant="System.Data.SQLite" name="SQLite Data Provider" description=".NET Framework Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite, Version=1.0.97.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
			<remove invariant="System.Data.SQLite.EF6" />
			<add name="SQLite Data Provider (Entity Framework 6)" invariant="System.Data.SQLite.EF6" description=".NET Framework Data Provider for SQLite (Entity Framework 6)" type="System.Data.SQLite.EF6.SQLiteProviderFactory, System.Data.SQLite.EF6, Version=1.0.97.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
		</DbProviderFactories>
	</system.data>
	<!-- Ohter stuff particular to my app -->
      <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
          <dependentAssembly>
            <assemblyIdentity name="System.Data.SQLite" publicKeyToken="db937bc2d44ff139" culture="neutral" />
            <bindingRedirect oldVersion="0.0.0.0-1.0.97.0" newVersion="1.0.97.0" />
          </dependentAssembly>
        </assemblyBinding>
      </runtime>
    </configuration>
