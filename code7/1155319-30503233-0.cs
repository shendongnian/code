    foreach(var entry in res)
    {
        string groupDay = entry.First().Created.ToString("dd.MM.yyyy");
        Console.WriteLine(groupDay);
        foreach(Person p in entry)
        {
            Console.WriteLine(p.Name);
        }
    }
