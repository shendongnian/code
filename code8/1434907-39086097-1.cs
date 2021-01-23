    var pivoted =
        from d in data
        group d by new { d.Id, d.Name } into region
        let g = region.SingleOrDefault(d => d.Region == "Global") ?? new Rev()
        let u = region.SingleOrDefault(d => d.Region == "USA") ?? new Rev()
        let e = region.SingleOrDefault(d => d.Region == "Euro") ?? new Rev()
        let a = region.SingleOrDefault(d => d.Region == "APAC") ?? new Rev()
        select new RevExtended
        {
            Id = region.Key.Id,
            Name = region.Key.Name,
            GlobalRevenue = g.Revenue,
            GlobalRank = g.Rank,
            UsaRevenue = u.Revenue,
            UsaRank = u.Rank,
            EuroRevenue = e.Revenue,
            EuroRank = e.Rank,
            ApacRevenue = a.Revenue,
            ApacRank = a.Rank,
        };
