    //this should be disabled temporarily
    _context.Configuration.LazyLoadingEnabled = false;
    var allposts = _context.Posts.Where(t => t.PostAuthor.Id == postAuthorId)
                           .Select(e => new {
                               e,//for later projection
                               e.Comments,//cache Comments
                               //cache filtered Attachments
                               Attachments = e.Attachments.Where(a => a.Owner is Author),
                               e.PostAuthor//cache PostAuthor
                            })
                           .AsEnumerable()
                           .Select(e => e.e).ToList();
