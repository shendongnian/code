    var project = agg.Project(r =>
        new{
            id = r.CampaignId,
            Last24H = r.RequestedOn.Value > DateTime.Today.AddDays(-1) ? 1 : 0,
            HasRequested = (r.RequestedOn.Value > new DateTime() ? 1 : 0),  //for some reason has value does not work (it is always true)
            Date = r.RequestedOn});
    var match = project.Match(p => p.id == id);
    var group = match.Group(
        r => r.id, 
        g => new CampaignStatistics{
                ExistingCustomers = g.Count(),
                TotalOrdered = g.Sum(p => p.HasRequested),
                LastOrder = g.Max(w => w.Date),
                FirstOrder = g.Min(w => w.Date),
                Last24HOrders = g.Sum(p => p.Last24H)});
