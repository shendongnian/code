    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) {throw new NotImplementedException();}
        public CustomPrincipal(CustomIdentity identity)
        {
            Identity = identity;
        }
    }
