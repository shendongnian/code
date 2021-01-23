    public class DefaultUserManager : IIdentityManager {
        private ApplicationUserManager innerManager;
        public DefaultUserManager() {
            this.innerManager = ApplicationUserManager.Instance;
        }
        //..other code removed for brevity
        public async Task<IIdentityResult> ConfirmEmailAsync(string userId, string token) {
            var result = await innerManager.ConfirmEmailAsync(userId, token);
            return result.AsIIdentityResult();
        }
        //...other code removed for brevity
    }
