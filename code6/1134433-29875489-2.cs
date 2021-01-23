    var conStr = 
    (
        from css in ConfigurationManager.ConnectionStrings
        where !(css.Name == "LocalSqlServer" || css.Name == "LocalMySqlServer")
        select new ConnectionString
        {
            name = css.Name,
            conString = css.ConnectionString,
            provider = css.ProviderName,
        }
    ).ToList();
