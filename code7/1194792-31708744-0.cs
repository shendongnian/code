    var replacedIndex = 2;
    var newDictionary = 
        oldDictionary.GroupBy(x => x.Value.ElementAt(replacedIndex ))
                     .ToDictionary(group => group.Key, group =>
                     {
                         var collections = group.Select(x => x.Value).ToList();
                         foreach (var collection in collections)
                         {
                              collection[replacedIndex] = group.Key;
                         }
                         return collections;
                     });
