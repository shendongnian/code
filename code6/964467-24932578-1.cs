        <connectionStrings>
        <add name="dbConnection"
          connectionString="Data Source=.\data.sqlite" providerName="System.Data.SQLite" />
      </connectionStrings>
      <system.data>
        <DbProviderFactories>
          <remove invariant="System.Data.SQLite" />
          <add name="SQLite Data Provider" invariant="System.Data.SQLite" description="Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite" />
        <!--  Leave this in there if you want to have EF working with your project -->    
          <remove invariant="System.Data.SQLite.EF6" />
          <add name="SQLite Data Provider (Entity Framework 6)" invariant="System.Data.SQLite.EF6" description=".Net Framework Data Provider for SQLite (Entity Framework 6)" type="System.Data.SQLite.EF6.SQLiteProviderFactory, System.Data.SQLite.EF6" />
        
        </DbProviderFactories>
      </system.data>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
    <providers>
      <provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6, Version=1.0.93.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
      <provider invariantName="System.Data.SQLite.EF6" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6" />
    </providers>
        <!-- This only works for sql server localdb edition 
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
          <parameters>
        <parameter value="v11.0" />
          </parameters>
        </defaultConnectionFactory> -->
      </entityFramework>
