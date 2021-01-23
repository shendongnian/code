    public static class DependencyHelper
    {
        public static List<DelegatingHandler> GetMessageHandlers(this IDependencyResolver dependencyResolver)
        {
            return dependencyResolver.GetServices(typeof (DelegatingHandler)).Cast<DelegatingHandler>().ToList();
        }
    }
