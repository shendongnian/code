    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AuthorizationOptions>(options =>
            {
                options.AddPolicy("ManageStore", policy => policy.RequireClaim("Action", "ManageStore"));
            });
        }
    }
    public class StoreController : Controller
    {
        [Authorize(Policy = "ManageStore"), HttpGet]
        public async Task<IActionResult> Manage() { ... }
    }
 
