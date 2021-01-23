    public class CustomUserTokenProvider : IUserTokenProvider<ApplicationUser, string>
    {
        public Task<string> GenerateAsync(string purpose, UserManager<ApplicationUser, string> manager,
            ApplicationUser user)
        {
            return
                //logic to generate code
        }
        public Task<bool> IsValidProviderForUserAsync(UserManager<ApplicationUser, string> manager, ApplicationUser user)
        {
            throw new NotImplementedException();
        }
        public Task NotifyAsync(string token, UserManager<ApplicationUser, string> manager, ApplicationUser user)
        {
            throw new NotImplementedException();
        }
        public Task<bool> ValidateAsync(string purpose, string token, UserManager<ApplicationUser, string> manager,
            ApplicationUser user)
        {
            //logic to validate code
        }
    }
        
