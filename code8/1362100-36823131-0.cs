    public class UserPrincipal : IPrincipal {
        string[] roles;
        public UserPrincipal (IIdentity identity, param string[] roles) {
            this.Identity = identity;
            this.roles = roles ?? new string[]{ };
        }
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) {
            return roles.Any(s => s == role);
        }
    }
