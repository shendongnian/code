    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Bearer")]
    public class AbstractController: ControllerBase
    {
        protected string UserId()
        {
            var principal = HttpContext.User;
            if (principal?.Claims != null)
            {
                foreach (var claim in principal.Claims)
                {
                   log.Debug($"CLAIM TYPE: {claim.Type}; CLAIM VALUE: {claim.Value}");
                }
            }
            return principal?.Claims?.SingleOrDefault(p => p.Type == "username")?.Value;
        }
    }
