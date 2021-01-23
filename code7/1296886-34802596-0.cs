    using (var db = new MyDbContext())
    {
        var posts = db.Posts
            .Include(p => p.User)
            .Where(p => p.ID == 0)
            .Select(p => new PostsDTO
            {
                Name = p.Name,
                Username = p.User.Username
            });
    }
