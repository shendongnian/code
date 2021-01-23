    var q = (
        from c1 in dbContext.Set<Class1>()
        from c2 in dbContext.Set<Class2>()
        from c3 in dbContext.Set<Class3>()
        where c1.Id == c2.Class1Id
        && c2.Id == c3.Class2Id
        select new { c1, c2, c3 }
    );
    object var = ...; // Some value
    if (var is decimal)
    {
        q = q.Where(x => x.c3.ValueAsDecimal == (decimal)var);
    }
    else if (var is DateTime)
    {
        q = q.Where(x => x.c3.ValueAsDate == (DateTime)var);
    }
    // TODO: Add other types of 'var' 
    
    var queryable = q.Select(x => x.c1);
