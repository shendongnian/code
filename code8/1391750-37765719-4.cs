        public class RootService : IRootService
        {
            public INestedService NestedService { get; set; }
            public RootService(Func<string,INestedService> nestedServiceFactory)
            {
                NestedService = nestedServiceFactory("ConnectionStringHere");
            }
            public void DoSomething()
            {
                // implement
            }
        }
    or resolve it per call
        public class RootService : IRootService
        {
            public Func<string,INestedService> NestedServiceFactory { get; set; }
            public RootService(Func<string,INestedService> nestedServiceFactory)
            {
                NestedServiceFactory = nestedServiceFactory;
            }
            public void DoSomething(string connectionString)
            {
                var nestedService = nestedServiceFactory(connectionString);
                // implement
            }
        }
