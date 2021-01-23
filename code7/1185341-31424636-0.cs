    // naive string-string dictionary equality comparer
    class YourDictEqualsComparer : EqualityComparer<Dictionary<string, string>>
    {
      public override bool Equals(Dictionary<string, string> x, Dictionary<string, string> y)
      {
        if (x == null || y == null)
          return Default.Equals(x, y);
        if (!x.Comparer.Equals(y.Comparer))
          return false;
        var setOfPairs = new HashSet<KeyValuePair<string, string>>(x);
        return setOfPairs.SetEquals(y);
      }
      public override int GetHashCode(Dictionary<string, string> obj)
      {
        if (obj == null)
          return 0;
        int seed = obj.Comparer.GetHashCode();
        return obj.Aggregate(seed, (hash, pair) => hash ^ pair.GetHashCode());
      }
    }
