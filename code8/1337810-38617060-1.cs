    public class AuthorizationFilterFactory : IFilterFactory
    {
        public bool IsReusable => true;
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var context = (IMyContext)serviceProvider.GetService(typeof(IMyContext));
            return new AuthorizationFilter(context);
        }
    }
