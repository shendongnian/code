    public class MyService : IService
    {
        public MyService([WithKey("DatabaseA")DbContext dbContext)
        {
        }
    }
