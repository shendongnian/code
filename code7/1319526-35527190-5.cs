    var contacts = query.Select(g => 
    {
     g.Key.Addresses = g.ToList();
     return g.Key;
    }).ToList();
    
    // now you can work off the Contacts list, which has only specific addresses
