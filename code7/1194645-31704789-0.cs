    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        // or inject it
        private DbContext _db = new DbContext();
        /// <summary>
        /// Check authorization
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var currentUser = HttpContext.Current.User;
            // do some checks, query a database, whatever
            bool allowed = _db.Users....
            if (!allowed)
            {
                filterContext.Result = new RedirectToRouteResult("Error", new RouteValueDictionary());
            }
        }
    }
