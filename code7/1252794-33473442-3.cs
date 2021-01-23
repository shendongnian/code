    using Identity.Extensions;
    public class YourClass()
    {
        public void DoSoemthingWithUser()
        {
             var identity = await this.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            // Use extension method
            var roles = identity.Roles();
        }
        public UserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<UserManager<IdentityUser>>(); 
            }
        }
    }
    
