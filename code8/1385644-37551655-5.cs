    ProviderBase provider = null;
    if(databaseType == "MySql")
    {
        provider = new MySqlProvider();
    }
    else if (databaseType == "MsSql")
    {
        provider = new MsSqlProvider();
    }
    var employees = provider.GetAllEmployees();
    //do something
