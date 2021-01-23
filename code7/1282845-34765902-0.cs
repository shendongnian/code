    public class DatabaseSetupTests : IDisposable
    {
        private MyDbContext Context { get; }
        private UserManager<ApplicationUser> UserManager { get; }
        public DatabaseSetupTests()
        {
            var services = new ServiceCollection();
            services.AddEntityFramework()
                .AddInMemoryDatabase()
                .AddDbContext<MyDbContext>(options => options.UseInMemoryDatabase());
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MyDbContext>();
            // Taken from https://github.com/aspnet/MusicStore/blob/dev/test/MusicStore.Test/ManageControllerTest.cs (and modified)
            // IHttpContextAccessor is required for SignInManager, and UserManager
            var context = new DefaultHttpContext();
            context.Features.Set<IHttpAuthenticationFeature>(new HttpAuthenticationFeature());
            services.AddSingleton<IHttpContextAccessor>(h => new HttpContextAccessor { HttpContext = context });
            var serviceProvider = services.BuildServiceProvider();
            Context = serviceProvider.GetRequiredService<MyDbContext>();
            UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        }
    ....
    }
