    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using YourMvcCoreProject.Models;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Hosting;
    
    namespace YourMvcCoreProject.Identity
    {
        public class ClaimsManager
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly IWebHostEnvironment _env;
            private ClaimsPrincipal _currentPrincipal;
    
            public ClaimsManager(
                ClaimsPrincipal currentPrincipal,
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager,
                IWebHostEnvironment env)
            {
                _currentPrincipal = currentPrincipal;
                _userManager = userManager;
                _signInManager = signInManager;
                _env = env;
            }
    
            /// <summary>
            /// At certain stages of user auth there is no user yet in context but there is one to work with in client code (e.g. calling from ClaimsTransformer)
            /// </summary>
            public ClaimsManager With(ClaimsPrincipal currentPrincipal)
            {
                _currentPrincipal = currentPrincipal;
                return this;
            }
            
            /// <param name="refreshSignin">Sometimes (e.g. when adding multiple claims at once) it is desirable to refresh cookie only once, for the last one </param>
            public async Task AddUpdateClaim(string claimType, string claimValue, bool refreshSignin = true)
            {
                await AddClaim(
                    claimType,
                    claimValue, 
                    async user =>
                    {
                        await RemoveClaim(user, claimType);
                    },
                    refreshSignin);
            }
    
            public async Task AddClaim(string claimType, string claimValue, bool refreshSignin = true)
            {
                await AddClaim(
                    claimType,
                    claimValue, 
                    async user =>
                    {
                        // allow reassignment in dev
                        if (_env.IsDevelopment()) 
                            await RemoveClaim(user, claimType);
    
                        if (GetClaim(claimType) != null)
                            throw new ClaimCantBeReassignedException(claimType);                
                    },
                    refreshSignin);
            }
    
            public async Task RemoveClaim(string claimType, bool refreshSignin = true)
            {
                AssertAuthenticated();
                var user = await _userManager.GetUserAsync(_currentPrincipal);
                await RemoveClaim(user, claimType);
                // reflect the change in the Identity cookie
                if (refreshSignin)
                    await _signInManager.RefreshSignInAsync(user);
            }
            
            private async Task AddClaim(string claimType, string claimValue, Func<ApplicationUser, Task> processExistingClaims, bool refreshSignin)
            {
                AssertAuthenticated();
                var user = await _userManager.GetUserAsync(_currentPrincipal);
                await processExistingClaims(user);
                var claim = new Claim(claimType, claimValue);
                CurrentIdentity().AddClaim(claim);
                await _userManager.AddClaimAsync(user, claim);
                // reflect the change in the Identity cookie
                if (refreshSignin)
                    await _signInManager.RefreshSignInAsync(user);
            }
    
            /// <summary>
            /// Due to bugs or as result of debug it can be more than one identity of the same type.
            /// The method removes all the claims of a given type.
            /// </summary>
            private async Task RemoveClaim(ApplicationUser user, string claimType)
            {
                AssertAuthenticated();
                var identity = CurrentIdentity();
                var claims = identity.FindAll(claimType).ToArray();
                if (claims.Length > 0)
                {
                    await _userManager.RemoveClaimsAsync(user, claims);
                    foreach (var c in claims)
                    {
                        identity.RemoveClaim(c);
                    }
                }
            }
            
            private Claim GetClaim(string claimType)
            {
                return CurrentIdentity().FindFirst(claimType);
            }    
    
            /// <summary>
            /// This kind of bugs has to be found during testing phase
            /// </summary>
            private void AssertAuthenticated()
            {
                if (!CurrentIdentity().IsAuthenticated)
                    throw new InvalidOperationException("User should be authenticated in order to update claims");
            }
    
            private ClaimsIdentity CurrentIdentity()
            {
                return (ClaimsIdentity) _currentPrincipal.Identity;
            }
        }
    
        
        public class ClaimCantBeReassignedException : Exception
        {
            public ClaimCantBeReassignedException(string claimType) : base($"{claimType} can not be reassigned")
            {
            }
        }
    // to register dependency put this into your Startup.cs and inject ClaimsManager into Controller constructor (or other class) the in same way as you do for other dependencies    
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ClaimsPrincipal>(s =>
                s.GetService<IHttpContextAccessor>().HttpContext.User);
            
            services.AddTransient<ClaimsManager, ClaimsManager>();
        }
    }
}
