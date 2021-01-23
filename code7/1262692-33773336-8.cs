    IEnumerable<ReturnType> result;
    using (var myContext = new DbContext())
    {
      result myContext.Database.SqlQuery<ReturnType>("StoredProcedureName", parameters)
        .ToList();         // calls the stored procedure
        // ToListAsync();  // Async
    {
