    foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
    {
        if (!(css.Name == "LocalSqlServer" || css.Name == "LocalMySqlServer"))
        {
            var conn = new ConnectionString
            {
               name = css.Name;
               conString = css.ConnectionString;
               provider = css.ProviderName;
            }
            conStr.Add(conn);
        }
    }
  
