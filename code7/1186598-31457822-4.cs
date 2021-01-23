    static void F<T>(T t) where T : IEnumerator<int>
    {
      t.MoveNext(); // OK, not boxed
      Console.WriteLine(t.Current);
    }
    static void G<T>(T t) where T : IEnumerator<int>
    {
      ((IEnumerator<int>)t).MoveNext(); // We said "Box!", it will box; 'Move' happens to a copy
      Console.WriteLine(t.Current);
    }
