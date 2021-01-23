    public List<NewRecord> GetRecords(DateTime pDateTime)
    {
        using (var db = YourDbContext())
        {
            var records = new List<Record>();
            return db.Records.Select(r =>
            {
                var record = new Record();
                record.info = r.info;
                var hm = DateTime.Parse(r.Time);
                var date = new DateTime(r.Date.Year, r.Date.Month, r.Date.Day, hm.Hour, hm.Minute);
                record.Date = date;
                return record;
            }).Where(r=>r.Date >pDateTime).ToList();
        }
    }
