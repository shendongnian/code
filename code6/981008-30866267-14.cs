    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Data.Models;
    
    namespace Data.Repository 
    {
        public class BlogPostRepository : Neo4jRepository<BlogPost>
        {
            // any custom methods or overridden methods here
        }
    }
