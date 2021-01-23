    var inner = session.Query<UserSystem>()
        .Where(e => e.System.SystPerf.Any(p => p.Perf_Adm_Portal == "S"))
        .Select(e => e.User.UserId);
    var query = session.Query<User>()
        .Where(i => inner.Contains(u.userId));
    
    var list = query
        // .Skip(y).Take(x) // paging
        .ToList();
