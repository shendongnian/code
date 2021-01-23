    List<Member> members = GetAllMembers(); // collection of all members
    var query = members.Select(m => m); // query without any filter conditions
    if (!string.IsNullOrEmpty(name)) { // null or "" don't want filter
        query = query.Where(m => m.Name == name); // we want filter by name
    }
    if (!string.IsNullOrEmpty(email)) {
        query = query.Where(m => m.EMail == email); // we want filter by email
    }
    // ... other filter conditions
    var result = query.ToList(); // collection of filtered members
