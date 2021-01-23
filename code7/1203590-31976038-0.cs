    public static class Extensions
    {
        public static string ScreenName(this IIdentity identity)
        {
            return ResolveScreenName();
        }
    }
