    private static random = new Random();
    
    ...
    List<int> possibleIndexes = Enumerable
      .Range(0, list.Count())
      .ToList();
    
    ...
    
    int idx = random.Next(possibleIndexes.Count());
    int index = possibleIndexes[idx];
    possibleIndexes.RemoveAt(idx);
    var socks = list[index];
    ...
