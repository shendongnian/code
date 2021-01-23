    var names = new List<Room>()
    {
        new Room() { Name = "Alpha", UserId = new List<int> { 10, 40 }},
        new Room() { Name = "Omega", UserId = new List<int> { 10, 20, 30 }},
    };
    // Aggragate needs an item to pass around, we will
    // seed it with the dictionary which will be the ultimate returned
    // value. The following lambda takes a dictionary object (`dict`)
    // and the current room ('current') to add to the dictionary. 
    names.Aggregate (new Dictionary<int, List<string>>(), (dict, current) =>
                {
                   current.UserId.ForEach(id => {
                                                   if (dict.ContainsKey(id) == false)
                                                      dict.Add(id, new List<string>());
    
                                                   dict[id].Add(current.Name);
                                                });
                    return dict;
                });
