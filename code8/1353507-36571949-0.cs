      public static class QueryExtensions
      {
          public IQueryable<MyClass> MyFilter(this IQueryable<MyClass> query, string p1)
          {
              return query.Where(p => p.SomeProperty == p1);
          }
      }
