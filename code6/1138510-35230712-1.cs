    using Microsoft.Extensions.PlatformAbstractions;
    public class Entity 
    {
        private readonly IDataContext dbContext;
        public class Entity()
        {
            this.dbContext = (IDataContext)CallContextServiceLocator.Locator.ServiceProvider
                                .GetService(typeof(IDataContext));
        }
         public void DoSomething()
         {
             var something = dbContext.Somethings.First();
         }
    }
