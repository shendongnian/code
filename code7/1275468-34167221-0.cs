    using (var db = new PRDatabaseEntities())
    {
        var query = db.Person
                      .GroupJoin(db.Repairs,
                                 p => p.PID, r => r.PID,
                                 (p, r) => new {
                                                   PID = p.PID,
                                                   Name = p.Name,
                                                   Surname = p.Surname,
                                                   Count = r.Count()
                                               };
    } 
