    public class CustomPrincipal : IPrincipal
    {
        private IPrincipal Principal;
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return Principal.IsInRole(role); }
        public CustomPrincipal(IPrincipal principal)
        {
            Principal = principal;
            //this force the load of the userid
            Identity = new CustomIdentity(principal.Identity);
        }
    }
