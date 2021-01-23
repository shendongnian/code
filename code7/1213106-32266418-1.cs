    public class BlogContextCustomInitializer : IDatabaseInitializer<BlogContext>
    {
        public void InitializeDatabase(BlogContext context)
        {
            if (context.Database.Exists())
            {
                if (!context.Database.CompatibleWithModel(true))
                {
                    // Do something...
                }
            }
        }
    }
