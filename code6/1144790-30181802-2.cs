    using (var db = new TestDbContext())
    {
          db.Test.Add(new Test { Id = 0, Language = "En" });
          db.Test.Add(new Test { Id = 0, Language = "Sb" });
    
          db.SaveChanges();    
     }
