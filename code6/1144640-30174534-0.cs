    <roleManager>
      <providers>
        <clear/>
        <add name="AspNetSqlRoleProvider" connectionStringName="MembershipConn" applicationName="/" type="System.Web.Security.SqlRoleProvider, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"/>
        <add name="AspNetWindowsTokenRoleProvider" applicationName="/" type="System.Web.Security.WindowsTokenRoleProvider, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"/>
      </providers>
    </roleManager>
