    public class ClaimsAccessAttribute : AuthorizeAttribute 
    {
        // in the real world you could get claim value form the DB, 
        // I simplified the example 
        public string ClaimType { get; set; }
        public string Value { get; set; }
        
        protected override bool AuthorizeCore(HttpContextBase context) 
        {
            return context.User.Identity.IsAuthenticated
                && context.User.Identity is ClaimsIdentity
                && ((ClaimsIdentity)context.User.Identity).HasClaim(x =>
                    x.Type == ClaimType && x.Value == Value);
        }
    }
