    ConcurrentDictionary<string, List<int>> idLists = SomeMethodOrSomething();
    List<int> idList;
    if (idLists.TryGetValue(someKey, out idList))
    {
      lock(idList)
      {
        if (!idList.Contains(someID))
          idList.Add(someID);
      }
    }
