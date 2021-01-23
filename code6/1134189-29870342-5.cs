    var groups = 
         from msg in _context.Messages
         group msg by msg.Grupo_ID into g
         where data.Keys.Contains(g.Key)
         select new {
             Item = g.Key,
             Messages = g.OrderByDescending(x => x.ID).ToList()
         };
    foreach (var g in groups)
        result.Add(
            g.Item, 
            g.Messages.TakeWhile(m => m.ID > data[g.Item]).ToList())
        
