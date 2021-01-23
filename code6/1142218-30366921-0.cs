    /// <summary>
    /// Custom authorization attribute for setting per-method accessibility 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class SetPermissionsAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// The name of each action that must be permissible for this method, separated by a comma.
        /// </summary>
        public string Permissions { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            SalesDBContext db = new SalesDBContext();
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationDbContext dbu = new ApplicationDbContext();
            bool isUserAuthorized = base.AuthorizeCore(httpContext);
            string[] permissions = Permissions.Split(',').ToArray();
            IEnumerable<string> perms = permissions.Intersect(db.Permissions.Select(p => p.ActionName));
            List<IdentityRole> roles = new List<IdentityRole>();
            if (perms.Count() > 0)
            {
                foreach (var item in perms)
                {
                    var currentUserId = httpContext.User.Identity.GetUserId();
                    var relatedPermisssionRole = dbu.Roles.Find(db.Permissions.Single(p => p.ActionName == item).RoleId).Name;
                    if (userManager.IsInRole(currentUserId, relatedPermisssionRole))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
