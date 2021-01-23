      List<Item> first = new List<Item>();
      List<Item> second = new List<Item>();
      HashSet<String> ids = new HashSet<string>(first.Select(item => item.Name));
      first.AddRange(second.Where(item => !ids.Contains(item.Name)));
 
