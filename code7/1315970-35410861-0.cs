    public static IEnumerable<string> GetValueOrEmpty(this DependencyGraph dg, string s)
    {
      HashSet<string> value;
      if (!dg.TryGetValue(s, out value)) return Enumerable.Empty<string>();
      return value;
    }
