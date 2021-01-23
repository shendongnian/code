     var groupItems = MyList
                        .GroupBy(g => g.Id)
                        .Select(s => new 
                                    { key = s.Key, 
                                      items = s.OrderBy(o => o.Item1)
                                               .ThenBy(t => t.Item2)
                                     }
                                )
                                .OrderBy(o => o.Id)
                                .SelectMany(sm => sm.Items).ToList();
   
     MyList.Clear();
     MyList.InsertRange(Mylist.Count, groupItems.Where(w => w.Code == 1));
     MyList.InsertRange(Mylist.Count, groupItems.Where(w => w.Code == 2));
