    public class AppInitializationFilter : IAsyncActionFilter
    {
        private DBContextWithUserAuditing _dbContext;
        public AppInitializationFilter(
            DBContextWithUserAuditing dbContext
            )
        {
            _dbContext = dbContext;
        }
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next
            )
        {
            string userId = null;
            int? tenantId = null;
            var claimsIdentity = (ClaimsIdentity)context.HttpContext.User.Identity;
            var userIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                userId = userIdClaim.Value;
            }
            var tenantIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == CustomClaims.TenantId);
            if (tenantIdClaim != null)
            {
                tenantId = !string.IsNullOrEmpty(tenantIdClaim.Value) ? int.Parse(tenantIdClaim.Value) : (int?)null;
            }
            _dbContext.UserId = userId;
            _dbContext.TenantId = tenantId;
            var resultContext = await next();
        }
    }
