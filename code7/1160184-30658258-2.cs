    class MyListComparer: Comparer<List<string>>
    {
        public override int Compare(List<string> x, List<string> y)
        {
            for (var ix = 0; ix < x.Count && ix < y.Count; ++ix)
            {
                var rslt = x[ix].CompareTo(y[ix]);
                if (rslt != 0)
                {
                    return rslt;
                }
            }
            // exhausted one of the lists.
            // Compare the lengths.
            return x.Count.CompareTo(y.Count);
        }
    }
    
    var comparer = new MyListComparer();
    var sortedList = dictionary.Select(kvp => 
        new KeyValuePair<int, List<string>>(kvp.Key, kvp.Value.OrderBy(v => v))
      .OrderBy(kvp => kvp.Value, comparer)
      .ThenBy(kvp => kvp.Key);
