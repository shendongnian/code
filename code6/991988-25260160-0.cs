    // this can be translated into a SQL query
    (from c in currentContext.GeneralAccounts
     select c)
    // turns the IQueryable into an IEnumerable, which means
    // from now on LINQ-to-Objects is used
    .AsEnumerable()
    .Select(p => new { CType = p.GetType() })
    .ToList()
