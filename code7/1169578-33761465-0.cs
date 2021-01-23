       public class ApplicationUser : IUser {
            public string ClientKey { get; set; }
            public string Id { get; set; }
            public string UserName { get; set; }
            public string NewsFilter { get; set; }
            public string FullName { get; set; }
    
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
        }
    
    
        public class StormpathUserStore : IUserStore<ApplicationUser>, IUserRoleStore<ApplicationUser> {
            private readonly IStormpathService _stormpathService;
    
            public StormpathUserStore(IStormpathService stormpathService) {
                if (stormpathService == null) {
                    throw new ArgumentNullException("stormpathService");
                }
                _stormpathService = stormpathService;
            }
    
            public Task AddToRoleAsync(ApplicationUser user, string roleName) {
                throw new NotImplementedException();
            }
    
            public Task RemoveFromRoleAsync(ApplicationUser user, string roleName) {
                throw new NotImplementedException();
            }
    
            public Task<IList<string>> GetRolesAsync(ApplicationUser user) {
    
                var groups = _stormpathService.GetUserGroups(_stormpathService.GetUserUrlFromId(user.Id));
                return Task.FromResult(groups.ToArray() as IList<string>);
            }
    
            public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName) {
    #if DEBUG
                var configuration = ObjectFactory.GetInstance<IConfiguration>();
    
                if (!string.IsNullOrWhiteSpace(configuration.DebugUser)) {
                    return Task.FromResult(configuration.DebugRoles.Split(',').Contains(roleName));
                }
    #endif
    
                var isInGroup =
                    _stormpathService.GetUserGroups(_stormpathService.GetUserUrlFromId(user.Id)).Contains(roleName);
                return Task.FromResult(isInGroup);
            }
    
            public void Dispose() {
            }
    
            public Task CreateAsync(ApplicationUser user) {
                throw new NotImplementedException();
            }
    
            public Task UpdateAsync(ApplicationUser user) {
                throw new NotImplementedException();
            }
    
            public Task DeleteAsync(ApplicationUser user) {
                throw new NotImplementedException();
            }
    
            public Task<ApplicationUser> FindByIdAsync(string userId) {
                var userData = _stormpathService.GetUser(_stormpathService.GetUserUrlFromId(userId));
                if (userData == null) {
                    return Task.FromResult((ApplicationUser)null);
                }
                var user = new ApplicationUser {
                    UserName = userData.UserName,
                    Id = userId,
                    ClientKey = userData.ClientId,
                    NewsFilter = userData.NewsFilter,
                    FullName = userData.FullName,
                };
                return Task.FromResult(user);
            }
    
            public Task<ApplicationUser> FindByNameAsync(string userName) {
                throw new NotImplementedException();
            }
        }
    
        // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
        public class ApplicationUserManager : UserManager<ApplicationUser> {
            public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store) {
            }
    
            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                IOwinContext context) {
                var manager =
                    new ApplicationUserManager(new StormpathUserStore(ObjectFactory.GetInstance<IStormpathService>()));
                // Configure validation logic for usernames
                manager.UserValidator = new UserValidator<ApplicationUser>(manager) {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };
    
                // Configure validation logic for passwords
                manager.PasswordValidator = new PasswordValidator {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = true,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true
                };
    
                // Configure user lockout defaults
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 15;
 
                var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null) {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity")) {TokenLifespan = TimeSpan.FromDays(14.0)};
                }
                return manager;
            }
        }
    
        // Configure the application sign-in manager which is used in this application.
        public class ApplicationSignInManager : SignInManager<ApplicationUser, string> {
            public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
                : base(userManager, authenticationManager) {
            }
    
            public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent,
                bool shouldLockout) {
                return Task.FromResult(
                    new StormpathService(new Configuration()).AuthenticateUser(userName, password) != null
                        ? SignInStatus.Success
                        : SignInStatus.Failure);
            }
    
            public override Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser) {
                return base.SignInAsync(user, true, rememberBrowser);
            }
    
            public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user) {
                var result = user.GenerateUserIdentityAsync((ApplicationUserManager) UserManager).Result;
                return Task.FromResult(result);
            }
    
            public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options,
                IOwinContext context) {
                return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
            }
        }
