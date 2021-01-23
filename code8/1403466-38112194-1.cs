    using (var db = dbFactory.Open())
    {
        db.DropAndCreateTable<Poco>();
        db.Insert(new Poco { Name = name });
        var results = db.Select<Poco>(x => x.Name == name);
        results.PrintDump();
    }
