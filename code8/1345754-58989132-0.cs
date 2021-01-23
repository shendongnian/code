    public class Singleton : ISingleton 
    {
        private readonly IServiceScopeFactory scopeFactory;
        public Singleton(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        public void MyMethod() 
        {
            using(var scope = scopeFactory.CreateScope()) 
            {
                var db = scope.ServiceProvider.GetRequiredService<DbContext>();
                // when we exit the using block,
                // the IServiceScope will dispose itself 
                // and dispose all of the services that it resolved.
            }
        }
    }
