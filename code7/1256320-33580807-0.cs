        public class StoreDB : DbContext
        {
           public StoreDB() : base("DefaultConnection")
            {
            }
            public virtual DbSet<StoryDB> Stories { get; set; }
        }
