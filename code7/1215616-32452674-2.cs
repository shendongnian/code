    using (var db = new TestEntities()) { 
        using (var tran = db.Database.BeginTransaction()) {
           db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Error ON");
                foreach (var id in Enumerable.Range(1, 20)) {
                    var ec = new Error();
                    ec.ErrorID = id;
                    db.Errors.Add(ec);
                }
                db.SaveChanges();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Error OFF");
                tran.Commit();
            }
        }
    }
