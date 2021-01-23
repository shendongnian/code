    public class AuthorizationFilterFactory : IFilterFactory
    {
        public bool IsReusable => true;
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            // manually find and inject necessary dependencies.
            var context = (IMyContext)serviceProvider.GetService(typeof(IMyContext));
            return new AuthorizationFilter(context);
        }
    }
