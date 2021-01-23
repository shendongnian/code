    public static class Empty<T>
    {
      public static IEnumerable<T> Sequence => Enumerable.Empty<T>();
    }
    public static class Unit
    {
      public static IEnumerable<T> Sequence<T>(T element) => Enumerable.Repeat(element, 1);
	}
