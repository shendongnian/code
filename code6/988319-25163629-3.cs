    using (var db = new AppContext())
    {
        // This is okay.
        var x = new RunDetail { Id = 1, BatchDetailId = 1, BatchDetail = new BatchDetail { Id = 1 } };
        db.RunDetails.Attach(x);
    }
    using (var db = new AppContext())
    {
        // This is okay.
        var x = new RunDetail { Id = 1, BatchDetailId = null, BatchDetail = null };
        db.RunDetails.Attach(x);
    }
    using (var db = new AppContext())
    {
        // This is okay.
        var x = new RunDetail { Id = 1, BatchDetailId = 1, BatchDetail = null };
        db.RunDetails.Attach(x);
    }
    using (var db = new AppContext())
    {
        // A referential integrity constraint violation occurred: The property 
        // value(s) of 'BatchDetail.Id' on one end of a relationship do not match the property 
        // value(s) of 'RunDetail.BatchDetailId' on the other end.
        var x = new RunDetail { Id = 1, BatchDetailId = null, BatchDetail = new BatchDetail { Id = 1 } };
        db.RunDetails.Attach(x);
    }
