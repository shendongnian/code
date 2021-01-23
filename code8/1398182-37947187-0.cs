    public sealed class AuthorizeLaoAttribute : AuthorizeAttribute
    {
        [Dependency]
        private IServiceUserService serviceUserService{ get; set; }
    }
