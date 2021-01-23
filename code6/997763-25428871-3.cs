    using (var db = new AppContext())
    {
        var names = new[] { "A", "B" };
        db.Set<Cat>().SyncData(names, x => x.Name, x => new Cat { Name = x });
        db.SaveChanges();
    }
