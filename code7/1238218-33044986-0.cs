    public class CustomIdentity : IIdentity
    {
        public IIdentity Identity { get; set; }
        public string UserId { get; private set; }
        public string AuthenticationType { get { return Identity.AuthenticationType; } }
        public bool IsAuthenticated { get { return Identity.IsAuthenticated; } }
        public string Name { get { return Identity.Name; } }
        public CustomIdentity(IIdentity identity)
        {
	        Identity = identity;
            UserId = Membership.GetUser(identity.Name).ProviderUserKey.ToString();
        }
    }
