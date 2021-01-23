    private ILoginService _loginService;
     
    public override void OnActionExecuting(ActionExecutingContext context)
            {
                _loginService = (ILoginService)context.HttpContext.RequestServices.GetService(typeof(ILoginService));
            }
