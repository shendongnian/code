    IQueryable<Message> query = messages
                               .OrderBy(o => o.MessageType)
                               .ThenBy(p => p.IsUrgent)
                               .ThenByDescending(p => p.Timestamp);
    //debug query.ToString() to see the generated sql
    //should be SELECT XXX WHERE YYY ORDER BY MessageType, IsUrgent, Timestamp DESC
    return query.ToList();
