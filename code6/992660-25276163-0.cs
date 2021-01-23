    <connectionStrings>
        <add name="BobServer" connectionString="bob's connection string" />
        <add name="MaryServer" connectionString="mary's connection string" />
        <add name="JimServer" connectionString="jim's connection string" />
    </connectionStrings>
    string 
        ConnectionName = Environment.UserName + "Server",
        ConString = ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;
    using (SqlConnection con = new SqlConnection(ConString))
    {
    }
