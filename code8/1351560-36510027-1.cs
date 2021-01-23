    public class BMClaimsAuthorize : AuthorizeAttribute
    {
        public string ClaimType { get; set; }
        public string Value { get; set; }
        public BMClaimsAuthorize() { }
        public BMClaimsAuthorize(string ClaimType, string Value)
        {
            this.ClaimType = ClaimType;
            this.Value = Value;
        }
        protected override bool AuthorizeCore(HttpContextBase context)
        {
            return context.User.Identity.IsAuthenticated
                && context.User.Identity is ClaimsIdentity
                && ((ClaimsIdentity)context.User.Identity).HasClaim(x =>
                    x.Type == ClaimType && x.Value == Value);
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.Result is HttpUnauthorizedResult)
                filterContext.Result = new RedirectResult("~/Account/DeniedAccess");
            
        }
    }
