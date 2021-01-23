    private class MockHttpContext : HttpContextBase {
        private readonly IPrincipal user;
        public MockHttpContext(MyUser identity , string[] roles = null) {
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
