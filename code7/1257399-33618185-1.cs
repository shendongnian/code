    var connectionString = DbHelper.BuildConnectionString("SERVERNAME", "DATABASE");
    using(MyAppEntities context = new MyAppEntities(connectionString))
    {
        var tableData = context.Table1.ToList();
    }
