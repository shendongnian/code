    var pivoted =
        from x in data.ToLookup(d => new { d.Id, d.Name })
        let g = x.SingleOrDefault(d => d.Region == "Global") ?? new Rev()
        let u = x.SingleOrDefault(d => d.Region == "USA") ?? new Rev()
        let e = x.SingleOrDefault(d => d.Region == "Euro") ?? new Rev()
        let a = x.SingleOrDefault(d => d.Region == "APAC") ?? new Rev()
        select new RevExtended
        {
            Id = x.Key.Id,
            Name = x.Key.Name,
            GlobalRevenue = g.Revenue,
            GlobalRank = g.Rank,
            UsaRevenue = u.Revenue,
            UsaRank = u.Rank,
            EuroRevenue = e.Revenue,
            EuroRank = e.Rank,
            ApacRevenue = a.Revenue,
            ApacRank = a.Rank,
        };
