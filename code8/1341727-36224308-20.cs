    public class CurrentUserProfileFilter : IAuthorizationFilter
    {
        private readonly MyDbContext context;
        public CurrentUserAuthorizationFilter(MyDbContext context)
        {
            this.context = context;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var currentUserName = filterContext.HttpContext.User.Identity.Name;
            // Set the ViewBag for the request.
            filterContext.Controller.ViewBag.UserName = currentUserName;
            var userBirthdate = 
                from user as this.context.AspNetUsers
                where user.UserName == currentUserName
                select birthdate;
        
            if (userBirthdate.Date == DateTime.Now.Date)
            {
                filterContext.Controller.ViewBag.Message = "Happy Birthday!";
            }
        }
    }
