    var departments = new Dictionary<string, int>()
    {
        { "HR", 33 },
        { "Management", 8 },
        { "Marketing", 21 },
        { "Marketin", 4 },
        { "Sales", 44 }
    };
    
    var baseText  = "Market";
    var validText = "Marketing";
    
    var removal = departments.ToList()
                             .Where(itm => itm.Key.StartsWith(baseText) && 
                                           itm.Key.Equals(validText) == false)
                             .ToList();   
    
    removal.ForEach(itm => departments.Remove(itm.Key));
    
    departments[validText] += removal.Sum(itm => itm.Value);
