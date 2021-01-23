    using (var s = sf.OpenSession())
    using (var tx = s.BeginTransaction())
    {
    	var blogs = s.CreateCriteria<Blog>()
    		.SetMaxResults(30)
    		.List<Blog>();
    	var countOfBlogs = s.CreateCriteria<Blog>()
    		.SetProjection(Projections.Count(Projections.Id()))
    		.UniqueResult<int>();
    
    	Console.WriteLine("Number of blogs: {0}", countOfBlogs);
    	foreach (var blog in blogs)
    	{
    		Console.WriteLine(blog.Title);
    	}
    
    	tx.Commit();
    }
