    var result = ctx.DataGroups.Where(...).Select(d => new DataGroupView
    {
        DataGroup = d;
        RecentDataElements = d.DataElements.OrderByDescending(de => de.GeneratedDateTime)
           .FirstOrDefault();
    }
