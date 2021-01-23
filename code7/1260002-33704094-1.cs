    public class MyCustomAuthorizationFilterAttribute : Attribute, IFilterFactory, IOrderedFilter
    {
        private readonly Permision[] _permissions;
    
        public MyCustomAuthorizationFilterAttribute(params Permision[] permissions)
        {
            _permissions = permissions;
        }
    
        public int Order { get; set; }
    
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var store = serviceProvider.GetRequiredService<IPermissionStore>();
    
            return new MyCustomAuthorizationFilter(store, _permissions)
            {
                Order = Order
            };
        }
    }
    
    public class MyCustomAuthorizationFilter : IAuthorizationFilter, IOrderedFilter
    {
        private readonly IPermissionStore _store;
        private readonly Permision[] _permissions;
    
        public int Order { get; set; }
    
        public MyCustomAuthorizationFilter(IPermissionStore store, params Permision[] permissions)
        {
            _store = store;
            _permissions = permissions;
        }
    
        public void OnAuthorization(AuthorizationContext context)
        {
            // Check if the action has an AllowAnonymous filter
            if (!HasAllowAnonymous(context))
            {
                var user = context.HttpContext.User;
                var userIsAnonymous =
                    user == null ||
                    user.Identity == null ||
                    !user.Identity.IsAuthenticated;
    
                if (userIsAnonymous)
                {
                    Fail(context);
                }
                else
                {
                    // check the store for permissions for the current user
                }
            }
        }
    
        private bool HasAllowAnonymous(AuthorizationContext context)
        {
            return context.Filters.Any(item => item is Microsoft.AspNet.Authorization.IAllowAnonymous);
        }
    
        private void Fail(AuthorizationContext context)
        {
            context.Result = new HttpUnauthorizedResult();
        }
    }
    
    // Your action
    [HttpGet]
    [MyCustomAuthorizationFilter(Permision.CreateCustomer)]
    public IEnumerable<string> Get()
    {
        //blah
    }
