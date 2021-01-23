    public class Article
    {
        public int Id {get; set;}       // by convention will become primary key
        public int TopicId {get; set;}  // by convertion will become foreign key to Topic
        public Topic Topic {get; set;}  // an article "has" a Topic
        public string Title {get; set;}
        public string Introduction {get; set;}
        // etc.
    }
    public class Topic
    {
        public int Id {get; set;}       // by convention primary key
        public virtual ICollection<Article> Articles {get; set;}
        ...
        // other Topic properties
    }
    public class MyDbContext : DbContext
    {
        public DbSet<Topic> Topics {get; set;}
        public DbSet<Article> Articles {get; set;}
    }
