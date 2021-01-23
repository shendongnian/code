    public static class ClaimExtensions
    {
        public static void AddUpdateClaim(this IPrincipal currentPrincipal,    string key, string value, ApplicationUserManager userManager)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return;
            // check for existing claim and remove it
            var existingClaim = identity.FindFirst(key);
            if (existingClaim != null)
            {
                RemoveClaim(currentPrincipal, key, userManager);
            }
            // add new claim
            var claim = new Claim(key, value);
            identity.AddClaim(claim);
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(new ClaimsPrincipal(identity), new AuthenticationProperties() { IsPersistent = true });
            //Persist to store
            userManager.AddClaim(identity.GetUserId(),claim);
            
        }
        public static void RemoveClaim(this IPrincipal currentPrincipal, string key, ApplicationUserManager userManager)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return ;
            // check for existing claim and remove it
            var existingClaims = identity.FindAll(key);
            existingClaims.ForEach(c=> identity.RemoveClaim(c));
            //remove old claims from store
            var user = userManager.FindById(identity.GetUserId());
            var claims =  userManager.GetClaims(user.Id);
            claims.Where(x => x.Type == key).ToList().ForEach(c => userManager.RemoveClaim(user.Id, c));
           
        }
        public static string GetClaimValue(this IPrincipal currentPrincipal, string key)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return null;
            var claim = identity.Claims.First(c => c.Type == key);
            return claim.Value;
        }
        public static string GetAllClaims(this IPrincipal currentPrincipal, ApplicationUserManager userManager)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return null;
            var claims = userManager.GetClaims(identity.GetUserId());
            var userClaims = new StringBuilder();
            claims.ForEach(c => userClaims.AppendLine($"<li>{c.Type}, {c.Value}</li>"));
            return userClaims.ToString();
        }
       
    }
