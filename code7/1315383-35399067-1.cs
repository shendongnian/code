     var statusesCollection = database.GetCollection<Status>("statuses");
     var result= statusesCollection.AsQueryable()
                                   .OrderByDescending(e=>e.date)
                                   .GroupBy(e=>e.payment)
                                   .Select(g=>new Status{_id =g.First()._id,
                                                         payment = g.Key,
                                                         code=g.First().code,
                                                         date=g.First().date
                                                        }
                                           )
                                   .ToList();
