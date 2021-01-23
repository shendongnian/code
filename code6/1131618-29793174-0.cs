    IEnumerable<MyModel> t = from p in src
                            group p by p.Name into sl
                            select new MyModel()
                            {
                                Name = sl.Key,
                                ModelSublists = sl.Select(x => new MySubmodel 
                                                 {
                                                    Id = x.Id,
                                                    Title = x.Id         
                                                 }).ToList()
                            };
