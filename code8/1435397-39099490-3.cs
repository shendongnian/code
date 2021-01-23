    public Tuple<IEnumerable<Post>, IEnumerable<ImageFile>> getAllBlogData()
    {
        var AllPosts = _entities.Posts.ToList();
        Tuple<IEnumerable<Post>, IEnumerable<ImageFile>> model = null;
        foreach (var post in AllPosts)
        {
            var posts = AllPosts.Where(e => e.PostID == post.PostID);
            if (posts != null)
            {
                //checks if a blog post has images
                if (post.hasImages)
                {
                    var images = _entities.ImageFiles.Where(e => e.PostID == post.PostID);
                    model = new Tuple<IEnumerable<Post>, IEnumerable<ImageFile>>(posts, images);
                }
                else
                {
                    model = new Tuple<IEnumerable<Post>, IEnumerable<ImageFile>>(posts, null);
                }
            }
        }
        return model;
    }
