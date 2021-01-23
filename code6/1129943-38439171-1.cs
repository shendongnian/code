    static void Main(string[] args)
    {
    
        ConnectionStringSettings genusSettings = ConfigurationManager.ConnectionStrings["Genus_Connection_String"];
        if (genusSettings == null || string.IsNullOrEmpty(genusSettings.ConnectionString))
        {
            throw new Exception("Fatal error: Missing connecting string 'Genus_Connection_String' in web.config file");
        }
        string genusConnectionString = genusSettings.ConnectionString;
        EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder(genusConnectionString);
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(entityConnectionStringBuilder.ProviderConnectionString);
        string genusSqlServerName = sqlConnectionStringBuilder.DataSource;
        string genusDatabaseName = sqlConnectionStringBuilder.InitialCatalog;
    
        Console.WriteLine("genusSqlServerName = " + genusSqlServerName);
        Console.WriteLine("genusDatabaseName = " + genusDatabaseName);
        Console.ReadLine();
    }
