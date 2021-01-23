    public class CustomAuthenticationSessionStore : IAuthenticationSessionStore {
        // Your implementation depending on use case goes here.
        public Task RemoveAsync(string key) {
            throw new NotImplementedException();
        }
        public Task RenewAsync(string key, AuthenticationTicket ticket) {
            throw new NotImplementedException();
        }
        public Task<AuthenticationTicket> RetrieveAsync(string key) {
            throw new NotImplementedException();
        }
        public Task<string> StoreAsync(AuthenticationTicket ticket) {
            throw new NotImplementedException();
        }
    }
    var options = new CookieAuthenticationOptions() {
        AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
        CookieName = "ChatCookies",
        LoginPath = CookieAuthenticationDefaults.LoginPath,
        LogoutPath = CookieAuthenticationDefaults.LogoutPath,
        ExpireTimeSpan = TimeSpan.FromDays(1),
        SessionStore = new CustomAuthenticationSessionStore()
    };
