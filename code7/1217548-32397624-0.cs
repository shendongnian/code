    var allUsers	= new Dictionary<string, int>();
    allUsers.Add("Bob", 10);
    allUsers.Add("Tom", 20);
    allUsers.Add("Ann", 30);
    
    var users		= new List<string>();
    users.Add("Bob");
    users.Add("Tom");
    users.Add("Jack");
    
    var result	= allUsers.Join(users, o => o.Key, i => i, (o, i) => o);
    foreach(var r in result)
    {
        Console.WriteLine(r.Key + " " + r.Value);
    }
