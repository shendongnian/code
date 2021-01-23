    var duplicates = records.GroupBy(r => r.Name)
                            .Where(g => g.Count() > 1);
    foreach(var duplicateGroup in duplicates)
    {
        Console.WriteLine("Duplicates for: {0}", duplicateGroup.Key);
        foreach(var item in duplicateGroup)
        {
            Console.WriteLine("Id: {0}, Address: {1}", item.Id, item.Address);
        }
    }
