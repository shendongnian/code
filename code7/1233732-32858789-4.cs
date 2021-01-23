    List<ListItem> res = listItems.GroupBy(x => x.Item1)
                                  .Select(x =>
                                      {
                                           var lastItem = x.Last(); 
                                                //Or x.OrderByDescending(z => z.Item2).First()
                                           return new ListItem
                                              {
                                                 Item1 = x.Key,
                                                 Item2 = lastItem.Item2
                                              };
                                      }).ToList();
