    public class UserRegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IUserRegisterService _userRegisterService;
        public UserRegisterController(
            UserManager<ApplicationUser> userManager,
            IOptions<WebAppSettings> settings,
            IUserRegisterService userRegisterService)
        {
            _userManager = userManager;
            _userRegisterService = userRegisterService;
        }
        //...
    }
    internal class UserRegisterService : IUserRegisterService
    {
        private readonly IActiveDirectoryRepository _repoAd;
        public UserRegisterService(IActiveDirectoryRepository repoAd)
        {
            _repoAd = repoAd;
        }
    }
    internal class ActiveDirectoryRepository : IActiveDirectoryRepository
    {
        private readonly string _container;
        public ActiveDirectoryRepository(IOptions<WebAppSettings> settings)
        {
            _container = settings.Value.ContainerDomain;
        }
    }
    public class WebAppSettings
    {
        public string ContainerDomain { get; set; }
    }
     public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<WebAppSettings>(Configuration);
            // Add framework services.
            services.AddMvc();
            services.AddTransient<IActiveDirectoryRepository, ActiveDirectoryRepository>();
            services.AddTransient<IUserRegisterService, UserRegisterService>();
        }
