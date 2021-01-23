    public YourController : Controller
    {
      private readonly IHttpContextAccessor _httpContextAccessor;
      private readonly string _user;
      public YourController(IHttpContextAccessor httpContextAccessor)
      {
        _httpContextAccessor = httpContextAccessor;
        _user = _httpContextAccessor.HttpContext.User.Identity.Name;
      }
    }
