    public class SomeShapeTableProvider : IShapeTableProvider
    {
        private readonly Work<IAuthenticationService> _authenticationService;
        public SomeShapeTableProvider(Work<IAuthenticationService> authenticationService) {
            _authenticationService = authenticationService;
        }
        public void Discover(ShapeTableBuilder builder)
        {
            // add alternates
        }
    }
