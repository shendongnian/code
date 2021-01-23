    using (var s = sf.OpenSession())
    using (var tx = s.BeginTransaction())
    {
    	var blogs = s.CreateCriteria<Blog>()
    		.SetMaxResults(30)
    		.Future<Blog>();
    	var countOfBlogs = s.CreateCriteria<Blog>()
    		.SetProjection(Projections.Count(Projections.Id()))
    		.FutureValue<int>();
    
    	Console.WriteLine("Number of blogs: {0}", countOfBlogs.Value);
    	foreach (var blog in blogs)
    	{
    		Console.WriteLine(blog.Title);
    	}
    
    	tx.Commit();
    }
