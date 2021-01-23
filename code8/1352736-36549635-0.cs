            var Grouped = (from Group in (from client in clients
                                          group client by client.Id into clientGroup
                                          select new { Id = clientGroup.Key, Sum = clientGroup.Sum(cc => cc.Amount) })
                           orderby Group.Sum descending
                           select Group).Take(3).ToList(); ;
            var Top3 = Grouped.Take(3).ToList();
            var Others = Grouped.Skip(3).ToList();
