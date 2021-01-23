    List<ListItem> res = listItems.GroupBy(x => x.Item1)
                                  .Select(x =>
                                      {
                                           var lastItem = x.Last();
                                           return new ListItem
                                              {
                                                 Item1 = x.Key,
                                                 Item2 = lastItem.Item2
                                              };
                                      }).ToList();
