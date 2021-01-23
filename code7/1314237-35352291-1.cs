    var result = collection.Parents.GroupBy(c => c.type)
        .Select(g => new
                     {
                         type = g.Key,      
                         id = g.Select(p => p.Id).FirstOrDefault(),
                         value = g.SelectMany(p => p.Children
                                  .Where(c => c.Status == Status.y)
                                  .OrderByDescending(c => c.Date)).ToList()                           
                     })
         .Select(g => new Parent{Id = g.id, type = g.type, Children = g.value}).ToList();
