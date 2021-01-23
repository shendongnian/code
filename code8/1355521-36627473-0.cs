    List<MyObject> list; // MyObject has Id1, Id2
    Dictionary<Tuple<int, int>, int?> dict;
    var sortedObjects = 
        dict.OrderBy(kvp=>kvp.Value))
            .Select(kvp=>
                list.Single(obj =>
                    obj.Id1 == kvp.Key.Item1 
                    && obj.Id2 == kvp.Key.Item2
                )
            );
