    public class AppUserManager : UserManager<AppUser, int> {
        //.......
        public async Task<ClaimsIdentity> CreateIdentityAsync(int userId, string authenticationType) {
            var user = await this.FindById(userId);
            var userIdentity = await this.CreateIdentityAsync(user, authenticationType);
            return userIdentity;
        }
        //.....
    }
