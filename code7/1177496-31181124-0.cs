    var list = (from u in context.users
                            join ud in context.UserDetails on u.Id equals ud.UId
                            select new
                            {
                                u.Id,
                                u.Name,
                                u.Age,
                                ud.Key,
                                ud.Value
                            });
    
                var finallist = list.GroupBy(x => new { x.Id, x.Name,x.Age}).Select(x => new
                    {
                        x.Key.Id,
                        x.Key.Name,
                        x.Key.Age,
                        Height = x.Where(y => y.Key == "Height").Select(y => y.Value).FirstOrDefault(),
                        Eyes = x.Where(y => y.Key == "Eyes").Select(y => y.Value).FirstOrDefault(),
                        Hair = x.Where(y => y.Key == "Hair").Select(y => y.Value).FirstOrDefault()
                    }).ToList();
