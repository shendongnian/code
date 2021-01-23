    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] {new Claim(claimType, claimValue) };
        }
    }
    public class ClaimRequirementFilter : IAsyncActionFilter
    {
        readonly Claim _claim;
        public ClaimRequirementFilter(Claim claim)
        {
            _claim = claim;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {            
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
            else
            {
                await next();
            }
        }
    }
    [Route("api/resource")]
    public class MyController : Controller
    {
        [ClaimRequirement(MyClaimTypes.Permission, "CanReadResource")]
        [HttpGet]
        public IActionResult GetResource()
        {
            return Ok();
        }
    }
