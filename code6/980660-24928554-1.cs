    // preload all api and user entities
    _context.Apis.Load();
    _context.Users.Load();
    
    // batch add new statistics
    statistic.User = _context.Users.Local.Single(x => x.Id == statistic.UserId);
    statistic.Api = _context.Api.Local.Single(x => x.Id == statistic.ApiId);
    _context.Statistics.Add(statistic);
