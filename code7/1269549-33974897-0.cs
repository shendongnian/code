    public static class FindExtensions
    {
      public static bool Find(this IEnumerable<ICanBeFoundById> xs, int someID)
      {
        return xs.Where(x=>x.Id == someID)
      }
    }
