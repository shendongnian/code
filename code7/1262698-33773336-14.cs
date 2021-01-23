    IEnumerable<ReturnType> result;
    using (var myContext = new DbContext())
    {
      result = myContext.Database.SqlQuery<User>("GetUsers", parameters)
        .ToList();         // calls the stored procedure
        // ToListAsync();  // Async
    {
