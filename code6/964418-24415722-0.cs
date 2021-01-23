    var query = list3.GroupBy(r => r.Name)
                    .Select(grp => new People
                    {
                        Name = grp.Key,
                        Siblings = grp.SelectMany(r => r.Siblings).ToList(),
                    });
