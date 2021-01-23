    using (var db = new MyContext())
    {
        var myEntity = db.MyEntitys.First();
        myEntity.Url = "I changed this.";
        var entry = db.ChangeTracker.Entries<MyEntity>().First();
        var originalValue = entry.Property(p => p.Url).OriginalValue;
    }
