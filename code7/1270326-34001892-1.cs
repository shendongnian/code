    var postInfo = db.Posts.Select(p => new
    {
        Post = p,
        Comments = p.Comments.Take(5),
        TotalNumberOfComments = p.Comments.Count
    })
