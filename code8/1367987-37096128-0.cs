    public static class ClaimsIdentityExtensions
    {
        private static readonly ConcurrentDictionary<string, UserInformation> CachedUserInformations = new ConcurrentDictionary<string, UserInformation>();
        public static IEnumerable<UserInformation> GetUserInformationClaims(this ClaimsIdentity identity)
        {
            return identity
                .Claims
                .Where(c => c.Type == ClaimTypes.UserData)
                .Select(c => CachedUserInformations.GetOrAdd(
                    c.Value,
                    JsonConvert.DeserializeObject<UserInformation>));
        }
    }
