        public static class TokenProvider
    {
        [UsedImplicitly] private static DataProtectorTokenProvider<IdentityUser> _tokenProvider;
        public static DataProtectorTokenProvider<IdentityUser> Provider
        {
            get
            {
                if (_tokenProvider != null)
                    return _tokenProvider;
                var dataProtectionProvider = new DpapiDataProtectionProvider();
                _tokenProvider = new DataProtectorTokenProvider<IdentityUser>(dataProtectionProvider.Create());
                return _tokenProvider;
            }
        }
    }
