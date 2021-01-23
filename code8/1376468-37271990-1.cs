    Vehicles finalList = TableData.Select(a => new Vehicles()
    {
        vehID = a.Id,
        vehDescription = a.des,
        vehValCriteria = TableData.Where(b => b.StepslistId == a.StepslistId)
        .Select(c => new StepsList()
        {
                    steps = c.Steps,
                    stepChannelsCriteria = TableData.Where(d => d.channelId == c.channelId)
                    .select(e => new MovChannels()
                    {
                        name = e.name,
                        criteria = TableData.Where(f => f.criteriasId = e.criteriasId)
                        .Select(g => new Criterias()
                        {
                            values = g.Values,
                            time = g.Time
                        }).ToList()
                    }).ToList()
             }).ToList()
        }).ToList();
