        public BloggingContext() 
        { 
            this.Configuration.ProxyCreationEnabled = false; 
        }  
>
        public DbSet<Blog> Blogs { get; set; } 
        public DbSet<Post> Posts { get; set; } 
    }
