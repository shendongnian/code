    class AutoKeyDictionary<TValue> : IEnumerable<TValue> where TValue : class
    {
      readonly List<TValue> list = new List<TValue>();
      public int Add(TValue val)
      {
        if (val == null)
          throw new ArgumentNullException(nameof(val), "This collection will not allow null values.");
        list.Add(val);
        return list.Count - 1;
      }
      public void RemoveAt(int key)
      {
        // do not remove ('list.Count' must never decrease), overwrite with null
        // (consider throwing if key was already removed)
        list[key] = null;
      }
      public TValue this[int key]
      {
        get
        {
          var val = list[key];
          if (val == null)
            throw new ArgumentOutOfRangeException(nameof(key), "The value with that key is no longer in this collection.");
          return val;
        }
      }
      public int NextKey => list.Count;
      public int Count => list.Count(v => v != null); // expensive O(n), Linq
      public bool ContainsKey(int key) => key >= 0 && key < list.Count && list[key] != null;
      public TValue TryGetValue(int key) => (key >= 0 && key < list.Count) ? list[key] : null;
      public void Clear()
      {
        for (var i = 0; i < list.Count; ++i)
          list[i] = null;
      }
      public IEnumerator<TValue> GetEnumerator() => list.Where(v => v != null).GetEnumerator(); // Linq
      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
      public int FirstKeyOf(TValue val) => list.IndexOf(val);
      public IDictionary<int, TValue> ToDictionary()
      {
        var retColl = new SortedList<int, TValue>(list.Count);
        for (var i = 0; i < list.Count; ++i)
        {
          var val = list[i];
          if (val != null)
            retColl.Add(i, val);
        }
        return retColl;
      }
      // and so on...
    }
