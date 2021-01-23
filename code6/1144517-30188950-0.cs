    public static void Main(string[] args)
    {
        using( var db = new BloggingContext() )
        {
            for( int i = 0; i < 10; ++i )
            { 
                var blog = new Blog() { /* as before */ };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
            for( int i = 0; i < 10; ++i )
            { 
                var fkBlog = GetBlog(db);
                var post = new Post()
                {
                    /* as before */
                };
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }
    }
    public static Blog GetBlog()
    {
        using(var db = new BloggingContext())
        {
            return GetBlog(db);
        }
    }
    private static Blog GetBlog(BloggingContext db)
    {
        return db.Blogs.OrderBy(x=>Guid.NewGuid()).FirstOrDefault();
    }
