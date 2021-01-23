    public static class Helper 
    {
       public static List<T> MyAdd<T>(this List<T> collection, T item)
       {
          collection.Add(item);
          return collection;
       }
    }
