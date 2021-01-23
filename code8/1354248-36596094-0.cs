    var result = activityTypes.Where(type=>isAllowed(type.Id)).Select(type => new CategoryViewModel
    {
        Id = type.Id,//This is where I want to add only items that are in the allowedA array
        Text = type.Name,
        Types = activities.Where(a => a.ParentId == type.Id&&isAllowed(a.Id)).Select(t => new TaxonomyMemberTextItem
        {
            Id = t.Id, //This is where I want to add only items that are in the allowedB array
            Text = t.Name
        }).ToList()
    }).ToArray();
