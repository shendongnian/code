    var query = Posts
                  .GroupBy(p => p.Type)
                  .SelectMany(g => 
                       {
                          var result = g.OrderByDescending(p => p.Date);
                          return g.Key == null ? result ? Enumerable.Repeat(result.First(), 1);
                       });
