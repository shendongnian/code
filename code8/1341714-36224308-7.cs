    public interface IDbContextFactory<TContext>
    {
        TContext Create();
    }
    public class DbContextFactory<TContext> : IDbContextFactory<TContext>
    {
        private readonly IDependencyResolver dependencyResolver;
        public DbContextFactory(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }
        public TContext Create()
        {
            return this.dependencyResolver.GetService<TContext>();
        }
    }
    public class CurrentUserProfileFilter : IAuthorizationFilter
    {
        private readonly IDbContextFactory<DbContext> dbContextFactory;
        public CurrentUserAuthorizationFilter(IDbContextFactory<DbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var currentUserName = filterContext.HttpContext.User.Identity.Name;
            // Set the ViewBag for the request.
            filterContext.Controller.ViewBag.UserName = currentUserName;
            // Resolve the context for the current request
            var context = this.dbContextFactory.Create();
            var userBirthdate = 
                from user as context.AspNetUsers
                where user.UserName == currentUserName
                select birthdate;
        
            if (userBirthdate.Date == DateTime.Now.Date)
            {
                filterContext.Controller.ViewBag.Message = "Happy Birthday!";
            }
        }
    }
