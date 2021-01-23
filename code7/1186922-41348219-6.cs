    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] {new Claim(claimType, claimValue) };
        }
    }
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly Claim _claim;
        public ClaimRequirementFilter(Claim claim)
        {
            _claim = claim;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
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
