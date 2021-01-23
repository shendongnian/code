    public IEnumerable<Record> GetRecords(DateTime after)
    {
       using (var db = new TheDbContext())
       {
          return db.Records
             .Where(r => r.When > after);
       }
     }
