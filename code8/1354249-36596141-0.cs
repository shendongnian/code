                activityTypes.Where(x=>allowedA.Contains(x.Id)).Select(type => new CategoryViewModel
                {
                    Id = type.Id,
                    Text = type.Name,
                    Types = activities.Where(a => a.ParentId == type.Id &&  allowedB.Contains(a.Id)).Select(t => new TaxonomyMemberTextItem
                    {
                        Id = t.Id, 
                        Text = t.Name
                    }).ToList()
                })
