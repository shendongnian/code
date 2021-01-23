      public static class UserManagerExtensions{
        public static async Task<ApplicationUser> getCurrentUser(this UserManager userManager, string userid)
        {
            var user = (ApplicationUser)await userManager.FindByIdAsync(userid);
            return user;
        }
        
        public static async Task<int> editCurrentUser(this UserManager userManager, ApplicationUser user)
        {
            await userManager.UpdateAsync(user);
            return 1;
        }
    
    }
