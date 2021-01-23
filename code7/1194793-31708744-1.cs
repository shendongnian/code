    var replacedIndex = 2;
    var newDictionary = 
        oldDictionary.GroupBy(x => x.Value.ElementAt(replacedIndex))
                     .ToDictionary(group => group.Key, group => group.Select(x =>
                     {
                         var collection = x.Value;
                         collection[replacedIndex] = x.Key;
                         return collection;
                     }));
