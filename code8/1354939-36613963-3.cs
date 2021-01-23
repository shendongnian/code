    public class YourContext : DbContext
    {
        // You can pass either dbContext_1, dbContext_2, dbContext_3, dbContext_4 as connection string name
        public YourContext(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        {
        }
    }
