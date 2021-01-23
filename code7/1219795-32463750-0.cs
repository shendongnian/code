    var query = Posts
                  .GroupBy(p => p.Type)
                  .Select(g => g.OrderByDescending(p => p.Date).FirstOrDefault()).ToList()
    var lostNullItems = Posts.Where(p => p.Type == null && !query.Contains(p));
    var newQuery = query.Union(lostNullItems);
