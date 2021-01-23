    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Hosting;
    
    namespace MyMvcCoreProj.Controllers
    {
        public class AppController : Controller
        {
            protected readonly UserManager<ApplicationUser> _userManager;
            protected readonly SignInManager<ApplicationUser> _signInManager;
            protected readonly IWebHostEnvironment _env;
    
            protected AppController(
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager,
                IWebHostEnvironment env)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _env = env;
            }
    
            protected async Task AddUpdateClaim(string claimType, string claimValue)
            {
                await AddClaim(
                    claimType,
                    claimValue, 
                    async user =>
                    {
                        await RemoveClaim(user, claimType);
                    });
            }
    
            protected async Task AddClaim(string claimType, string claimValue)
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
                    });
            }
            
            private async Task AddClaim(string claimType, string claimValue, Func<ApplicationUser, Task> processExistingClaims)
            {
                var user = await _userManager.GetUserAsync(User);
    
                await processExistingClaims(user);
    
                await _userManager.AddClaimAsync(user, new Claim(claimType, claimValue));
                
                // reflect the change in the Identity cookie
                await _signInManager.RefreshSignInAsync(user);
            }
    
            private async Task RemoveClaim(ApplicationUser user, string claimType)
            {
                var identity = (ClaimsIdentity) User.Identity;
                var claims = identity.FindAll(claimType).ToArray();
                await _userManager.RemoveClaimsAsync(user, claims);
                foreach (var c in claims)
                {
                    identity.RemoveClaim(c);
                }
            }
    
            private Claim GetClaim(string claimType)
            {
                var identity = (ClaimsIdentity) User.Identity;
                return identity.FindFirst(claimType);
            }
        }
    }
    
        public class ClaimCantBeReassignedException : Exception
        {
            public ClaimCantBeReassignedException(string claimType) : base($"{claimType} can not be reassigned")
            {
            }
        }
