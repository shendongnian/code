    using (var db = new AppContext())
    {
        db.BatchDetails.Add(new BatchDetail { Id = 1 });
        db.RunDetails.Add(new RunDetail { Id = 1, BatchDetailId = 1 });
        db.SaveChanges();
    }
