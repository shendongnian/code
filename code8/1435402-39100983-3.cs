    private List<Tuple<Post, IEnumerable<ImageFile>>> GetAllBlogPosts()
    {
        var allPosts =
		    _entities.Posts.Select(
			   post =>
				    new Tuple<Post, IEnumerable<ImageFile>>(
                        post,
					    _entities.ImageFiles.Where(x => x.PostID == post.PostID)));
        return allPosts.ToList();
    }
