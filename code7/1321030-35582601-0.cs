    var groups = new Dictionary<int, new HashSet<int>>();
    // populate the groups
    groups[1] = new HashSet<int>(new[] { 1,2,15 });
    groups[2] = new HashSet<int>(new[] { 3,4,7,33,22,100 });
    int number = 5;
    int groupId = 4;
    bool numberExists = groups.Values.Any(x => x.Contains(number));
    // check if the group exists
    if(groups.ContainsKey(groupId)) 
    {
        // if there is already a group that contains the number
        // merge it with the current group and add the new number
        if(numberExists)
        {
             var group = groups.First(kvp => kvp.Value.Contains(number));
             groups[group.Key] = new HashSet<int>(groups[group.Key].Concat(groups[groupId]);
             groups[group.Key].Add(number);
             groups[groupId] = new HashSet<int>();
        }
        // otherwise just add the new number
        else 
        {
             groups[groupId].Add(number);
        }
    }
    else 
    {
        if(numberExists)
        {
            var group = groups.Values.First(x => x.Contains(number));
            group.Add(number);
        }
        else 
        {
           groups[groupId] = new HashSet<int>();
           groups[groupId].Add(number);
        }
    }
