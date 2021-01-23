    public static void OnceAndAll<T>(this IEnumerable<T> source, Action<T> once, Action<T> all)
    {
      using(var en = source.GetEnumerator())
        if(en.MoveNext())
        {
          var current = en.Current;
          once(current);
          all(current);
          while(en.MoveNext())
            all(en.Current);
        }
    }
    public static void Once<T>(this IEnumerable<T> source, Action<T> once)
    {
      using(var en = source.GetEnumerator())
        if(en.MoveNext())
          once(en.Current);
    }
    //Overrides for where the value is not actually used:
    public static void OnceAndAll<T>(this IEnumerable<T> source, Action once, Action<T> all)
    {
      source.OnceAndAll(_ => once(), all);
    }
    public static void OnceAndAll<T>(this IEnumerable<T> source, Action<T> once, Action all)
    {
      source.OnceAndAll(once, _ => all());
    }
    public static void OnceAndAll<T>(this IEnumerable<T> source, Action once, Action all)
    {
      source.OnceAndAll(once, _ => all());
    }
    public static void Once<T>(this IEnumerable<T> source, Action once)
    {
      source.Once(_ => once());
    }
