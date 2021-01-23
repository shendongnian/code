    using (var dbContextTransaction = db.Database.BeginTransaction()) 
    {
        b = new B { };
        a = new A { b = b };
        db.Add(b);
        db.Add(a);
        db.SaveChanges()
        dbContextTransaction.Commit(); 
    }
