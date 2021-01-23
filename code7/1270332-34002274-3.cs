     var posts = dbContext.Posts.
            Select(s => new PostDto
            {
                Id = s.PostId,
                Title= s.PostTitle,
                TotalCommentCount = s.Comments.Count(),
                Comments = s.Comments.OrderByDescending(f => f.Id).Take(5)
                    .Select(x => new PostDto
                    {
                        Id = x.CommentId,
                        Name = x.CommentText
                    }).ToList()
            }).ToList();
