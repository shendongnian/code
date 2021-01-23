                Dictionary<string, List<string>> two_Dict = new Dictionary<string, List<string>>();
                var keyIndex = two_Dict.Keys.AsEnumerable()
                    .Select((x, i) => new { index = i, value = x })
                    .ToList();
                var result = (from key1 in keyIndex
                              from key2 in keyIndex
                              where key1.index > key2.index 
                              select new { key1 = key1, list1 = two_Dict[key1.value], key2 = key2, list2 = two_Dict[key2.value] })
                             .Where(x => AreEqual(x.list1, x.list2)).Select(y => new { key1 = y.key1.value, key2 = y.key2.value}).ToList();       
            }
            static bool AreEqual<T>(List<T> x, List<T> y)
            {
                // same list or both are null
                if (x == y)
                {
                    return true;
                }
                // one is null (but not the other)
                if (x == null || y == null)
                {
                    return false;
                }
                // count differs; they are not equal
                if (x.Count != y.Count)
                {
                    return false;
                }
                for (int i = 0; i < x.Count; i++)
                {
                    if (!x[i].Equals(y[i]))
                    {
                        return false;
                    }
                }
                return true;
            }​
