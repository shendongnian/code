     <entityFramework>
        <providers>
          <provider invariantName="MySql.Data.MySqlClient"
                    type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6" />
        </providers>
      </entityFramework>
      <system.data>
        <DbProviderFactories>
          <remove invariant="MySql.Data.MySqlClient"></remove>
          <add name="MySQL Data Provider"
               invariant="MySql.Data.MySqlClient"
               description=".Net Framework Data Provider for MySQL"
               type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data,  Version=6.8.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" />
        </DbProviderFactories>
      </system.data>
