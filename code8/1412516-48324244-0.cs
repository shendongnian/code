    private async Task<List<MyModelType>> GetAsyncListFromIEnumerable(
      List<MyModelIEnumerableType> mylist, 
      DateTime startDate, 
      DateTime endDate)
    {
      var result = from e in erogazioni
                   where e.StartDate >= startDate 
                   && e.EndDate <= endDate
                   select new MyModelIEnumerableType
                   {
                     // Set of the properties here
                   };
      return await result.AsQueryable().ToListAsync();
    }
