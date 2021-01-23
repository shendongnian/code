    using (var context = new BloggingContext()) 
    { 
    var blogs = from b in context.Blogs 
                   where b.Name.StartsWith("B") 
                   select b; 
     
    // Query for the Blog named ADO.NET Blog 
    var blog = context.Blogs 
                    .Where(b => b.Name == "ADO.NET Blog") 
                    .FirstOrDefault(); 
    }
    
