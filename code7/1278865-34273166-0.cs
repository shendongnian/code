    using (TestDbContext db = new TestDbContext())
    {
         // operation 1
         db.SaveChanges();    
         // operation 2
         db.SaveChanges();
    }
