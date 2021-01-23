    IEnumerable<seat> query = seats.AsEnumerable();
    
    if(!string.IsNullOrEmpty(section))
        query = query.Where(s => s.Section == section);
    
    if(!string.IsNullOrEmpty(row))
        query = query.Where(s => s.Row == row);
    
    if(!string.IsNullOrEmpty(id))
        query = query.Where(s => s.Id == id);
    
    List<seat> results = query.ToList(); // deferred execution
