    var newList = oldList.GroupBy(x => x.Id, 
                            (key, values) => 
                               new Food() {
                                 Id = key,
                                 Text = values.First().Text,
                                 Description = string.Join(", ", 
                                                  values.Select(v => v.Description))
                                })
                         .SelectMany(x => x)
                         .ToList();
