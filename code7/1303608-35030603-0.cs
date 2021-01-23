    public class MyRepo : IRepo
    {
        private readonly YourDbContext dbContext;
        public MyRepo(YourDbContext ctx)
        {
            dbContext = ctx;
        }
    }
