    public interface IUserManagerSegment
    {
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> CreateAsync(ApplicationUser user);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
        Task<ApplicationUser> FindByNameAsync(string userName);
        Task<bool> IsEmailConfirmedAsync(string userId);
        Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword);
        Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId);
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
        void Dispose(bool disposing);
        void Dispose();
    }
