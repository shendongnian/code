      // Filter directly the List
      public static List<T> FilterByLinqExpression<T>(this IList<T> list, string linqFilterExpression)
      {
         var result = list.AsQueryable().Where(linqFilterExpression);
         return result.ToList<T>();
      }
