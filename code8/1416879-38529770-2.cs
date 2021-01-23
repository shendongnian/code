    var newModelList = modelList.GroupBy(ml => ml.GroupID)
    .Select(g => new MyModel
    {
        ID = g.OrderByDescending(x => x.ID).First().ID,
            GroupID = g.Key
    }).ToList();
