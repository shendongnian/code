    public IEnumerable<Record> GetRecords(DateTime after)
    {
       var afterDate = after.Date;
       using (var db = new TheDbContext())
       {
          var records = db.Records
             .Where(r => r.Date >= afterDate);
          foreach (var r in records)
          {
             if (r.Date > afterDate) yield return r;
             else 
             {
                var when = r.Date + TimeSpan.Parse(r.Time, "hh:mm");
                if (when > after) yeild return r;
             }
          }
       }
     }
