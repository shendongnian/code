    var result = ctx.DataGroups.Where(...).Select(d => new DataGroupViewModel
    {
        DataGroup = d;
        RecentDataElements = d.DataElements.OrderByDescending(de => de.GeneratedDateTime)
           .FirstOrDefault();
    }
