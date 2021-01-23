    List<Requirement> result = requirements
        .GroupBy(l => l.CRMOpportunityNumber)
        .Where(cl => cl.All(l => l.Category != "work commenced"))
        .Select(cl => new Requirement
        {
            CRMOpportunityNumber = cl.First().CRMOpportunityNumber,
            OpportunityTitle = cl.First().OpportunityTitle,
            ClientName = cl.First().ClientName,
            TentativeStartDate = cl.Min(c => c.TentativeStartDate),
            TotalPositions = cl.Sum(c => c.Required),
            RegionName = cl.First().RegionName,
            TotalCVProposed = cl.Sum(c => c.Associates.Count),
            TotalDeployed = cl.Sum(c => c.Associates.Count(x => x.IsIdentified == true)),
            NetGap = cl.Sum(c => c.Required) - cl.Sum(c => c.Associates.Count(x => x.IsIdentified == true))
        }).OrderByDescending(l => l.CRMOpportunityNumber)
        .ToList();
