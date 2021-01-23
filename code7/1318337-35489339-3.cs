    public static class Extensions
    {
       public static IEnumerable<TestClass> SelectResult(this IQueryable<ItemResponse> q)
       {
          return q.GroupBy(ir => ...)
       }
    }
