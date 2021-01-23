    var statuses = new [] { "Live", "Pending", "Expired" };
    var posts = _context.Post
        .Where(p => p.ModeratorId != null && statuses.Contains(p.Status.Name))
        .GroupBy(p => new { Id = p.ModeratorId, Name = p.Moderator.Name })
        .Select(g => new ModeratorPostViewModel 
        {
            Id = g.Key.Id,
            Name = g.Key.Name,
            CountOfPosts = g.Count()
        })
        .OrderBy(m => m.Name)
        .ToList();
