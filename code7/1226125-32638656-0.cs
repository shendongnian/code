    var returnVal = new List<Group>();
    
    if (IsUserInRole("Admin"))
    {
    	returnVal.AddRange(groupsByMembersFirst);
    }
    if (IsUserInRole("B"))
    {
    	returnVal.AddRange(groupsByMembersFirst.Where(g => g.GroupTypeName != "Bikes"));
    }
    if (IsUserInRole("C"))
    {
    	returnVal.AddRange(groupsByMembersFirst.Where(g => g.GroupTypeName != "Cars"));
    }
    if (IsUserInRole("N"))
    {
    	returnVal.AddRange(groupsByMembersFirst.Where(g => g.GroupTypeName != "NanoCars"));
    }
    return groupsByMembersFirst;
