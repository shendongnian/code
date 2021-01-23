    var groups = 
         from msg in _context.Messages
         group msg by msg.Grupo_ID into g
         where data.Keys.Contains(g.Key)
         select new {
             Item = g.Key,
             Messages = g.ToList()
         };
    foreach (var group in groups)
        result.Add(group.Item , group.Messages.Where(m => m.ID > data[group.Item]))
        
