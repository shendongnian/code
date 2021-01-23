    var dict = new Dictionary<long, List<string>>();
    foreach(var user in userProfiles)
    {
        foreach(var interest in user.Interests)
        {
            List<string> names;
            if(dict.TryGetValue(interest, out names))
                names.Add(user.Name);
            else
                dict.Add(interest, new[] { user.Name }.ToList());
        }
    }
    
    long[] interestIds = new[] { 4, 8 };
    
    HashSet<string> profiles = new HashSet<string>();
    foreach (var interestId in interestIds)
        profiles.UnionWith(dict[interestId]);
