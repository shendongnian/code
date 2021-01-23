    var galaxySector = new List<PlanetPhase>
    {
        new PlanetPhase
        {
            Name = "Saturn",
            StartDatePhase = new DateTime(2016, 7, 22, 8, 0, 0),
            EndDatePhase = new DateTime(2016, 7, 22, 9, 30, 0)
        },
        new PlanetPhase
        {
            Name = "Saturn",
            StartDatePhase = new DateTime(2016, 7, 22, 10, 0, 0),
            EndDatePhase = new DateTime(2016, 7, 22, 11, 0, 0)
        },
        new PlanetPhase
        {
            Name = "Saturn",
            StartDatePhase = new DateTime(2016, 7, 22, 11, 20, 0),
            EndDatePhase = new DateTime(2016, 7, 22, 12, 30, 0)
        },
        new PlanetPhase
        {
            Name = "Saturn",
            StartDatePhase = new DateTime(2016, 7, 22, 14, 0, 0),
            EndDatePhase = new DateTime(2016, 7, 22, 16, 0, 0)
        },
        new PlanetPhase
        {
            Name = "Saturn",
            StartDatePhase = new DateTime(2016, 7, 22, 18, 30, 0),
            EndDatePhase = new DateTime(2016, 7, 22, 19, 30, 0)
        },
        new PlanetPhase
        {
            Name = "Saturn",
            StartDatePhase = new DateTime(2016, 7, 22, 19, 45, 0),
            EndDatePhase = new DateTime(2016, 7, 22, 21, 0, 0)
        },
    };
    PlanetPhase previous = null;
    int groupon = 0;
    var results = galaxySector.GroupBy(p => p.Name)
        .Select(grp => new
        {
            PlanetName = grp.Key,
            Phases = grp.OrderBy(p => p.StartDatePhase)
                    .Select(p =>
                    {
                        if (previous != null
                            && p.StartDatePhase - previous.EndDatePhase > TimeSpan.FromMinutes(30))
                        {
                            groupon++;
                        }
                        previous = p;
                        return new
                        {
                            groupOn = groupon,
                            p.StartDatePhase,
                            p.EndDatePhase
                        };
                    })
                    .GroupBy(x => x.groupOn)
                    .Select(g => new
                    {
                        Start = g.Min(x => x.StartDatePhase),
                        End = g.Max(x => x.EndDatePhase)
                    })
                    .ToList()
        });
    foreach (var r in results)
    {
        Console.WriteLine(r.PlanetName);
        foreach (var p in r.Phases)
            Console.WriteLine($"\t{p.Start} - {p.End}");
    }
