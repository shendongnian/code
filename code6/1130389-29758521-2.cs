    '''
    '''
    post.UrlSlug = str;
    post.BlogUserEmail = User.Identity.Name;
    post.PostedOn = DateTime.Now;
    post.Tags.Add(new Tag(){Name = 'asp.net'})
    db.Posts.Add(post);
    db.SaveChanges();
