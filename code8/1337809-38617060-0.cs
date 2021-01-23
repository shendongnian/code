    public class MyAuthorizationFilter : IAuthorizationFilter, IFilterFactory
    {
        private readonly IMyContext context;
        public MyAuthorizationFilter(IMyContext context)
        {
            this.context = context;
        }
        public bool IsReusable => false;
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService(typeof (IMyContext));
            return new MyAuthorizationFilter(context);
        }
    }
