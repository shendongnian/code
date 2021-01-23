    <roleManager enabled="true" defaultProvider="AspNetSqlRoleProvider">
      <providers>
        <clear/>
          <add connectionStringName="ApplicationServices" 
            applicationName="/" 
            name="AspNetSqlRoleProvider" 
            type="System.Web.Security.SqlRoleProvider, System.Web"/>
      </providers>
    </roleManager>
