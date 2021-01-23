    var query = list.GroupBy(r => r.date.Month)
                .Select(grp => new
                    {
                        Month = grp.Key,
                        IdsCount = grp.GroupBy(r => r.id)
                                        .ToDictionary(subGroup => subGroup.Key, 
                                                      subGroup => subGroup.Count()),
                    });
