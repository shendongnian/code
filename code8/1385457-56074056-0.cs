    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        public RoleController(
            UserManager<User> userManager
            )
        {
            this.userManager = userManager;
        }
        // GET api/role
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<string>> Get()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var user = await userManager.FindByIdAsync(userId);
            var role = await userManager.GetRolesAsync(user);
            return role;
        }
    }
