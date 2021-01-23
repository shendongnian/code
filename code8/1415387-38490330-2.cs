    var statuses = new [] { "Live", "Pending", "Expired" };
    var posts = _context.Moderator
        .OrderBy(m => m.Name)
        .Select(m => new ModeratorPostViewModel 
        {
            Id = m.Id,
            Name = m.Name,
            CountOfPosts = m.ModeratorPosts.Count(p => statuses.Contains(p.Status.Name))
        })
        .Where(m => m.CountOfPosts != 0)
        .ToList();
