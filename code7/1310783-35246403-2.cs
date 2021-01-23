    public static class IdentityHelper
    {
        public static string GetFreshProfilePicture(this IIdentity identity)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return userManager.FindById(identity.GetUserId()).ProfilePicture;
        }
    }
