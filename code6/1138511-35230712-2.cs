    public class Entity 
    {
        private readonly IDataContext dbContext;
        // The DI will auto inject this for you
        public class Entity(IDataContext dbContext)
        {
            this.dbContext = dbContext;
        }
         public void DoSomething()
         {
             // dbContext is already populated for you
             var something = dbContext.Somethings.First();
         }
    }
