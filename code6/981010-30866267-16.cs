    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    
    namespace Neo4jRepository.Data.Model
    {
        public class BlogPost : Neo4jEntity
        {
            public string Author { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTimeOffset Created { get; set; }        
    
            public BlogPost()
            {
                Label = "BlogPost";
                Created = DateTimeOffset.UtcNow;
            }
        }
    }
