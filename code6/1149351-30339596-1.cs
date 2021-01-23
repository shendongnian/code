    using (var db = OpenDbConnection())
    {
        db.DropAndCreateTable<Foo>();
        db.DropAndCreateTable<Bar>();
        db.ExecuteNonQuery("PRAGMA foreign_keys = ON");
        var foo = new Foo
        {
            Bar = new Bar
            {
                Name = "Hello"
            }
        };
        db.Save(foo);
        db.SaveReferences(foo, foo.Bar);
        var saved = db.Select<Foo>();
        db.DeleteById<Foo>(saved.First().Id);
        Assert.False(db.Exists<Bar>(c => c.FooId == saved.First().Id));
    }
