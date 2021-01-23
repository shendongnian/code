    var items = db.Context.SomeTable
                          .Where(x => x.abc == someAbc && x.zyx == someZyx);
    
    foreach(var item in items)
    {
            item.AuditId = newAuditId;
            item.TimeStamp = newTimestamp;
    }
    
    db.Context.SaveChanges();
