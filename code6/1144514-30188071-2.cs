    public static void Main(string[] args)
    {
        using( var db = new BloggingContext() )
        {
            for( int i = 0; i < 10; ++i )
            { 
                var blog = new Blog() { Name = i.ToString(), Description = "Desc", Url = String.Format( "http://{0}", i ) };
    
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }
    
        using( var db = new BloggingContext() )
        {
            for( int i = 0; i < 10; ++i )
            { 
                var fkBlog = db.Blogs.OrderBy( x=>Guid.NewGuid() ).FirstOrDefault();
    
                var post = new Post()
                {
                    Blog = fkBlog,
                    Content = String.Format("Blog Content {0}", i),
                    Title = String.Format("Blog Title {0}", i)
                };
    
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }
    }
