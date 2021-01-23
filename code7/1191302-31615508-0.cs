    void showListContents1(List<string> l)
    {
      var en = l.GetEnumerator();
      try
      {
        while(en.MoveNext())
          Console.WriteLine("{0}", en.Current);
      }
      finally
      {
        en.Dispose();
      }
    }
    void showListContents(List<string> l)
    {
      using(var en = l.GetEnumerator())
      {
        while(en.MoveNext())
          Console.WriteLine("{0}", en.Current);
      }
    }
