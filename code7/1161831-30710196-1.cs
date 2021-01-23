    var posts = this.context.Posts
        .Select(p =>
        new Post()
        {
            PostID = p.PostID,
            Title = p.Title,
            Body = p.Body,
            Comment = p.Comment
            Project = p.Project,
            LikedByUser = this.context.PostLikes.Any(pl => pl.PostId = p.PostID)
        });
