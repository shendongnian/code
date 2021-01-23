    Blog blog = context.Blogs.FirstOrDefault(b => b.Title == blogTitle);
    
    // no blog with this title yet, create a new one
    if (blog == null) {
        blog = new Blog();
        blog.Title = blogTitle;
        blog.Posts = new Collection<Post>();
        context.Blogs.Add(blog);
    } 
    
    Post p = new Post();
    p.Title = postTitle;
    p.Content = "some content";
    blog.Posts.Add(p);
    	 
    context.SaveChanges();
