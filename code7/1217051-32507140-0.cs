      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework">
          <parameters>
            <parameter value="Data Source=.; Integrated Security=True; MultipleActiveResultSets=True" />
          </parameters>
        </defaultConnectionFactory>
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        </providers>
        <contexts>
            <context type="EasyEntity.EasyContext, EasyEntity">
                <databaseInitializer type="EasyEntity.EasyInitializer, EasyEntity" />
            </context>
        </contexts>
      </entityFramework>
