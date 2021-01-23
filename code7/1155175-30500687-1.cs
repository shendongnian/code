    System.Configuration.Configuration Config1 = WebConfigurationManager.OpenWebConfiguration("~");
    ConnectionStringsSection conSetting = (ConnectionStringsSection)Config1.GetSection("connectionStrings");
    string providerName = "System.Data.EntityClient";
    string conString = @"metadata=res://*/OWordpress.csdl|res://*/OWordpress.ssdl|res://*/OWordpress.msl;provider=System.Data.SqlClient;provider connection string=" + "\"data source=" + host + ";initial catalog=" + dbName + ";user id=" + userId + ";password=" + password + ";MultipleActiveResultSets=True;App=EntityFramework\"\'";
    ConnectionStringSettings StringSettings = new ConnectionStringSettings("OWordpressContainer", conString, providerName);
    conSetting.ConnectionStrings.Remove(StringSettings);
    conSetting.ConnectionStrings.Add(StringSettings);
    Config1.Save(ConfigurationSaveMode.Modified);
