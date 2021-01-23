    public interface IUserManager {
        //...other properties
        Task<IdentityUser> FindByIdAsync(string id);
    }
    public class IdentityUser {
        //...other properties
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
