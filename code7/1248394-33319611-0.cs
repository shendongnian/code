    IQueryable<SomeEntity> query = Session.Query<SomeEntity>();
    if (isEqOp)
        query = query.Where(e => e.Name == options.Value)
    if (isContainsOp)
        query = query.Where(e => e.Name.Contains(options.Value))
    
    query.ToList();
