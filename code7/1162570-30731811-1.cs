    Dictionary<Type1, Type2> d = new Dictionary<Type1, Type2>();
    var d2 = d.GroupBy(x => x.Value.SomeId)
              .Select(g => new KeyValuePair<Type1, Type2>(g.Key, g.First().Value))
              .ToDictionary(x => x.Key, y => y.Value)
              ;
