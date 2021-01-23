    using (var context = new BloggingContext()) 
    { 
        // Load all blogs and related posts 
        var blogs1 = context.Blogs 
                              .Include(b => b.Posts) 
                              .ToList(); 
     
        // Load one blogs and its related posts 
        var blog1 = context.Blogs 
                            .Where(b => b.Name == "ADO.NET Blog") 
                            .Include(b => b.Posts) 
                            .FirstOrDefault(); 
     
        // Load all blogs and related posts  
        // using a string to specify the relationship 
        var blogs2 = context.Blogs 
                              .Include("Posts") 
                              .ToList(); 
     
        // Load one blog and its related posts  
        // using a string to specify the relationship 
        var blog2 = context.Blogs 
                            .Where(b => b.Name == "ADO.NET Blog") 
                            .Include("Posts") 
                            .FirstOrDefault(); 
    }
