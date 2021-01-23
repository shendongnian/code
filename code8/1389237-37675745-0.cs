    var results = dogOwners.Select(x => new Owner() { OwnerId = x.OwnerId, DogsCount = x.Dogs.Count })
                            .Union(catOwners.Select(x => new Owner() { OwnerId = x.OwnerId, CatsCount = x.Cats.Count }))
                            .GroupBy(x => x.OwnerId)
                            .Select(x => 
                                    new Owner()
                                    {
                                        OwnerId = x.Key,
                                        CatsCount = x.Sum(y => y.CatsCount),
                                        DogsCount = x.Sum(y => y.DogsCount)
                                    });
