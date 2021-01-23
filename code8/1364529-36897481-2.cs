    public class MyService : IMyService 
    {
        priate IPrincipal principal;
        public MyService(Func<IPrincipal> principalFactory) 
        {
            this.principal = principalFactory();
        }
    }
