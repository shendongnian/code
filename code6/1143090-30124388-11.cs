    public class AuthenticationServiceProvider : IProvideAuthenticationService
    {
        private readonly Container _container;
        public AuthenticationServiceProvider(Container container)
        {
            _container = container;
        }
        public IAuthenticationService GetService(string requestMethod)
        {
            switch (requestMethod)
            {
                case "GET":
                    return new _container.GetInstance<HttpGetAuthenticationService>();
                case "POST":
                    return _container.GetInstance<HttpPostAuthenticationService>()
                default:
                    throw new NotSupportedException(string.Format(
                        "Cannot find AuthenticationService for requestMethod '{0}'",
                            requestMethod));
            }
        }
    }
