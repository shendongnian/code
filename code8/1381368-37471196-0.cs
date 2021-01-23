    using (var dc = new DbContext("your connection string or name"))
    {
        string edition = dc.Database.SqlQuery<string>("SELECT SERVERPROPERTY('edition')").Single();
        if(edition == "Enterprise")
        {
            //...
        }
        else
        {
            //...
        }
    }
