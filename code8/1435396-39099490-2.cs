    public List<Tuple<Post, IEnumerable<ImageFile>> getAllBlogData()
    {
        var list = new List<Tuple<Post, IEnumerable<ImageFile>>();
        Tuple<Post, IEnumerable<ImageFile>> tuple = null;
        var AllPosts = _entities.Posts.ToList();
        foreach (var post in AllPosts)
        {
            //checks if a blog post has images
            if (post.hasImages)
            {
                var images = _entities.ImageFiles.Where(e => e.PostID == post.PostID);
                tuple = new Tuple<Post, IEnumerable<ImageFile>>(post, images);
            }
            else
            {
                tuple = new Tuple<Post, IEnumerable<ImageFile>>(post, null);
            }
            list.Add(tuple);
        }
        return list;
    }
