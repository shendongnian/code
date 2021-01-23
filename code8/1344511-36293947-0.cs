    public static T Contains<T>(this IAssertion<IEnumerable<T>> assertion, T item)
    {
      // assertion logic
      return assertion.Value;
    }
    public static T Contains<T>(this IAssertion<IEnumerable<T>> assertion, Func<T, bool> func)
    {
      // assertion logic
      return assertion.Value;
    }
