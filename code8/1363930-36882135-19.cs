    public static IEnumerable InfiniteEnumerable()
    {
      var rnd = new Random();
      while(true)
      {
        yield return rnd.Next();
      }
    }
