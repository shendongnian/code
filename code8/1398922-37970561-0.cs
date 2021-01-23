    private class MockHttpContext : HttpContextBase {
        private readonly IPrincipal user;
        public MockHttpContext(string username, string[] roles = null) {
            var identity = new GenericIdentity(username);
            var principal = new GenericPrincipal(identity, roles ?? new string[] { });
            user = principal;
        }
        public override IPrincipal User {
            get {
                return user;
            }
            set {
                base.User = value;
            }
        }
    }
