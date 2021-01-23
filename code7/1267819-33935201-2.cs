     <configSections>
        <entityFramework>
           <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
          <providers>
              <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
          </providers>
        </entityFramework>
        <connectionStrings>
             <add name="DictionaryPlus" connectionString="Data Source=(localdb)\v11.0;Initial Catalog=DataBaseName;"
        providerName="System.Data.SqlClient"/>
        </connectionStrings>
     </configuration>
