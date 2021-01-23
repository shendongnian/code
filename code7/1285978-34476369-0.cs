    model = _kletsContext.GroupUser.Where(g => g.GroupId == groupId)
        .Include(gu => gu.User)
        .ThenInclude(u => u.Profile)
        .OrderByDescending(o => o.GroupId)
        .AsEnumerable();
