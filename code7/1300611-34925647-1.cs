    using (var db = new DbContext())
    {
        var post = new Post(name, description); // possibly try-catch here
        db.Posts.Add(post);
        db.SaveChanges();
        return post.Id;
    }
