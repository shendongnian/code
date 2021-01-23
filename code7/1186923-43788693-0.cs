    public enum PermissionItem
    {
        User,
        Product,
    	Contact,
    	Review,
    	Client
    }
    
    public enum PermissionAction
    {
        Read,
    	Create,
    }
    
    
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(PermissionItem item, PermissionAction action)
        : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { item, action };
        }
    }
    
    public class AuthorizeActionFilter : IAsyncActionFilter
    {
        private readonly PermissionItem _item;
        private readonly PermissionAction _action;
        public AuthorizeActionFilter(PermissionItem item, PermissionAction action)
        {
            _item = item;
            _action = action;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool isAuthorized = MumboJumboFunction(context.HttpContext.User, _item, _action); // :)
    
            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
    
            }
            else
            {
                await next();
            }
        }
    }
    
    public class UserController : BaseController
    {
        private readonly DbContext _context;
    
        public UserController( DbContext context) :
            base()
        {
            _logger = logger;
        }
    
        [Authorize(PermissionItem.User, PermissionAction.Read)]
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
    	}
    }
