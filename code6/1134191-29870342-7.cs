    // This is a single SQL query.
    var groups = 
         from msg in _context.Messages
         group msg by msg.Grupo_ID into g
         where data.Keys.Contains(g.Key)
         select new {
             Item = g.Key,
             // ordering helps us when we do the in-memory part.
             Messages = g.OrderByDescending(x => x.ID).ToList()
         };
    // This iterates the result set in memory
    foreach (var g in groups)
        result.Add(
            g.Item, 
            // input is ordered, we stop when an item is <= data[g.Item].
            g.Messages.TakeWhile(m => m.ID > data[g.Item]).ToList())
        
