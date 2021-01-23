    Model.Sample.GroupBy(x => new {x.Name, x.Address})
                .Select(x => 
                        new 
                         {
                            Name = x.Key.Name, 
                            Address = x.Key.Address,
                            Count = x.Count(),
                            obj = x.ToList()
                         });
