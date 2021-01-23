    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        // or inject it
        private DbContext _db = new DbContext();
       
        private string _filter;
        public RoleAuthorizeAttribute(string filter)
        {
            _filter = filter;
        }
        /// <summary>
        /// Check authorization
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var currentUser = HttpContext.Current.User;
            // do some checks, query a database, whatever
            string approvedRoles =  Helpers.QueryableExtensions.GetApprovedRoles(_filter);
            if (!currentUser.IsInRole(...))
            {
                filterContext.Result = new RedirectToRouteResult("Error", new RouteValueDictionary());
            }
        }
    }
