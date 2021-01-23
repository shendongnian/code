    var names = new List<Room>()
    {
        new Room() { Name = "Alpha", UserId = new List<int> { 10, 40 }},
        new Room() { Name = "Omega", UserId = new List<int> { 10, 20, 30 }},
    };
    
    var asDict = names.Aggregate (new Dictionary<int, List<string>>(), (dict, current) =>
                {
                   current.UserId.ForEach(id => {
                                                   if (dict.ContainsKey(id) == false)
                                                      dict.Add(id, new List<string>());
    
                                                   dict[id].Add(current.Name);
                                                });
                    return dict;
                });
