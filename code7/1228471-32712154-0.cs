    var userGroups = projectList
        .GroupBy(p => p.User)
        .OrderBy(g => g.Key);
    foreach(var grp in userGroups)
    {
        Console.WriteLine(grp.Key); // user
        foreach(Project p in grp)
            Console.WriteLine("{0} - {1}", p.Name, p.Value);
    }
