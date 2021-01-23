    <configSections>
      <section name="dataConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings, Microsoft.Practices.EnterpriseLibrary.Data, Version=5.1.0.0, Culture=neutral, PublicKeyToken=4133a635bb2789db" requirePermission="true" />
    </configSections>
    
    <dataConfiguration defaultDatabase="DatabaseConnectionString" />
    <connectionStrings>
    	<add name="DatabaseConnectionString" connectionString="Data Source=TestDb;Persist Security Info=True;User ID=Usrname;Password=Pwd!;Max Pool Size=500;" providerName="Oracle.DataAccess.Client" />        
    </connectionStrings>
