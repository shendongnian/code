    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    
    namespace MyProject
    {
        public class BloggingContextFactory : IDbContextFactory<BloggingContext>
        {
            public BloggingContext Create()
            {
                var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
                optionsBuilder.UseSqlite("Filename=./blog.db");
    
                return new BloggingContext(optionsBuilder.Options);
            }
        }
    }
