    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;
    
    namespace Controllers
    {
        public class BaseController : Controller
        {
            protected string GetCurrentUserIDFromClaims()
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
    
            protected List<string> AllClaimsFromAzure()
            {
                ClaimsIdentity claimsIdentity = ((ClaimsIdentity)User.Identity);
                return claimsIdentity.Claims.Select(x => x.Value).ToList();
            }
    
            protected string GetCurrentEmailFromAzureClaims()
            {
                return AllClaimsFromAzure()[3];
            }
        }
    }
