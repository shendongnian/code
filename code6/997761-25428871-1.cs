    using (var db = new AppContext())
    {
        var names = new[] { "A", "B" };
        db.Types.SyncData<Cat>(names, x => x.Name, x => new Cat { Name = x });
        db.SaveChanges();
    }
