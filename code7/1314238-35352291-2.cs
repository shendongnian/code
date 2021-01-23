    var result = collection.Parents.GroupBy(c => c.type)
        .Select(g => new Parent
                     {
                         type = g.Key,      
                         Id = g.Select(p => p.Id).FirstOrDefault(),
                         Children = g.SelectMany(p => p.Children
                                  .Where(c => c.Status == Status.y)
                                  .OrderByDescending(c => c.Date)).ToList()                           
                     }).ToList();
