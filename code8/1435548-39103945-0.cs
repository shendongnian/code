    class AutoKeyDictionary<TValue> where TValue : class
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
      public void Clear()
      {
        for (var i = 0; i < list.Count; ++i)
          list[i] = null;
      }
      // and so on...
    }
