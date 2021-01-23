    // these sentenses are all enumerated immediately
    db.PersonUsernames.ToList();
    db.PersonUsernames.Where(a => a.PersonID != 39).ToArray();
    db.PersonUsernames.Count();
    foreach(var person in db.PersonUsernames) { /* Do something */ }
 
    // but, these are not 
    string name = "";
    var query = db.PersonUsernames.Where(a => a.PersonID != 39);
    if (String.IsNullOrEmpty(name))
       query = query.Where(a => a.UserName == name);
    query = query.OrderBy(q => q.PersonID);
    // and when you want to enumerate it
    // you just have to call ToList or enumerate it using foreach
    query.ToList();
    query.ToArray();
    foreach(var q in query) { /* Do something */ }
