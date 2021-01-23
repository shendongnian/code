    IQueryable<MyQuery> query = DbContext.Table;
    if (something)
    {
        query = query.Where(x => x.z == true && x.zz == false)
    }
    else
    {
        query = query.Where(x => x.z == true);
    }
    var result = query.Select(x => new { x.a, x.b, x.c });
    foreach (var item in result)
    {
        // Do the work
    }
