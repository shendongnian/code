    foreach(var entry in res)
    {
        // Day is the same for all items in a group entry.
        string groupDay = entry.First().Created.ToString("dd.MM.yyyy");
        Console.WriteLine(groupDay);
        // list all names of persons in that group
        foreach(Person p in entry)
        {
            Console.WriteLine(p.Name);
        }
    }
