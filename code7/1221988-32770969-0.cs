    var sampleData = new List<Encounter>
    {
        new Encounter {Id = "1", Language = "1", VersionId = "A"},
        new Encounter {Id = "2", Language = "2", VersionId = "A"},
        new Encounter {Id = "3", Language = "1", VersionId = "B"},
        new Encounter {Id = "4", Language = "2", VersionId = "B"},
        new Encounter {Id = "5", Language = "1", VersionId = "A"},
        new Encounter {Id = "6", Language = "2", VersionId = "A"}
    };
    
    List<Encounter> fromStandardLinq = sampleData
            .GroupBy(e => new { e.Language, e.VersionId })
            .Select(e => new Encounter { Id = "0", Language = e.Key.Language, VersionId = e.Key.VersionId })
            .ToList();
    
    Console.WriteLine("fromStandardLinq:");
    foreach (var en in fromStandardLinq)
    {
        Console.WriteLine("{0} {1} {2}", en.Id, en.Language, en.VersionId);
    }
    
    var fromDynamicLinq1a = sampleData.AsQueryable()
            .GroupBy(@"new (Language, VersionId)", "it")
            .Select<Encounter>("new (\"0\" as Id, it.Key.Language, it.Key.VersionId)")
            ;
    
    Console.WriteLine("fromDynamicLinq1a:");
    foreach (Encounter en in fromDynamicLinq1a)
    {
        Console.WriteLine("{0} {1} {2}", en.Id, en.Language, en.VersionId);
    }
    
    var fromDynamicLinq1b = sampleData.AsQueryable()
            .GroupBy(@"new (Language, VersionId)", "it")
            .Select(new { Id = "9", Language = "9", VersionId = "9" }, "new (\"0\" as Id, it.Key.Language, it.Key.VersionId)")
            .Select(x => x)
            ;
    
    Console.WriteLine("fromDynamicLinq1b:");
    foreach (dynamic en in fromDynamicLinq1b)
    {
        Console.WriteLine("{0} {1} {2}", en.Id, en.Language, en.VersionId);
    }
    
    Console.WriteLine("fromDynamicLinq2a:");
    var rawResultFromDynamicLinq2a = sampleData.AsQueryable()
            .GroupBy(@"new (Language, VersionId)", "it")
            .Select(typeof(Encounter), "new (\"0\" as Id,it.Key.Language, it.Key.VersionId)")
            ;
    
    foreach (Encounter en in rawResultFromDynamicLinq2a)
    {
        Console.WriteLine("{0} {1} {2}", en.Id, en.Language, en.VersionId);
    }
    
    Console.WriteLine("fromDynamicLinq2b:");
    var rawResultFromDynamicLinq2b = sampleData.AsQueryable()
            .GroupBy(@"new (Language, VersionId)", "it")
            .Select(typeof(Encounter), new { Id = "9", Language = "9", VersionId = "9" }, "new (\"0\" as Id,it.Key.Language, it.Key.VersionId)")
            ;
    
    foreach (Encounter en in rawResultFromDynamicLinq2b)
    {
        Console.WriteLine("{0} {1} {2}", en.Id, en.Language, en.VersionId);
    }
