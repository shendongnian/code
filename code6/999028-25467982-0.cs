    var specificDate = new DateTime(1980, 1, 1);
    var results = (from x in input
                  group x by GetGroup(x, specificDate) into g
                  select new {
                      Time = g.Key, 
                      Images = g.ToList()
                  }).ToList();
