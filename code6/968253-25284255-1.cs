    using (var db = new AppContext())
    {
        db.EnableFilter("SoftDelete");
        var foos = db.Foos.Include(f => f.Bars).ToArray(); // works on Include
    }
    using (var db = new AppContext())
    {
        db.EnableFilter("SoftDelete");
        var foos = db.Foos.ToArray();
        foreach (var foo in foos)
        {
            var bars = foo.Bars; // works on lazy loading
        }
    }
    using (var db = new AppContext())
    {
        db.EnableFilter("SoftDelete");
        var foos = db.Foos.ToArray();
        foreach (var foo in foos)
        {
            db.Entry(foo).Collection(f => f.Bars).Load(); // works on manual loading
        }
    }
