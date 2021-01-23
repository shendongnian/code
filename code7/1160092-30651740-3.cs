    public static class DbSetExtensions
    {
      public static IEnumerable<T> Random(this IQueryable<T> source,int count)
      {
        var rowCount=source.Count();
        var rand = new Random();
        for(var x=0;x<count;x++)
        {
          var next=rand.Next(0,rowCount);
          yield return source.OrderBy(x=>x.id).Skip(next).First();
        }
      }
    }
