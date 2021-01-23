    public class MyCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        string newAccountNo = "102";
        public override Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            // first remove the old claim
            var claim = context.Principal.FindFirst(ClaimTypes.UserData);
            if (claim != null)
            {
                ((ClaimsIdentity)context.Principal.Identity).RemoveClaim(claim);
            }
            // add the new claim
            ((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim(ClaimTypes.UserData, newAccountNo));
            // replace the claims
            context.ReplacePrincipal(context.Principal);
            context.ShouldRenew = true;
            return Task.CompletedTask;
        }
    }
