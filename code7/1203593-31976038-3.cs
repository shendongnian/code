    public static class Extensions
    {
        public static string GetScreenName(this IIdentity identity)
        {
            return CurrentScreenName;
        }
    }
