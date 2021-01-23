      List<Item> first = new List<Item>();
      List<Item> second = new List<Item>();
      ... 
      // ids to exclude while adding
      HashSet<String> ids = new HashSet<string>(first.Select(item => item.Name),
        StringComparer.InvariantCultureIgnoreCase);
      // add all items from the second, except exluded 
      first.AddRange(second.Where(item => !ids.Contains(item.Name)));
 
