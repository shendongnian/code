    var postInfo = db.Posts.Select(p => new
    {
        Post = p,
        Comments = p.Comments.Take(5).ToList(),
        TotalNumberOfComments = p.Comments.Count
    })
