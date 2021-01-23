    var postWithComments = db.Posts.Select(x => new 
      {
        Post = x,
        Comments = x.Comments.Take(5),
        CommentsCount = x.Comments.Count()
      });
