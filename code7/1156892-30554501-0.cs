    public static class IdentityCustomExtension
        {
            public static int GetYourField(this IIdentity identity)
            {
                var appUser = (ApplicationUser)identity;
                return appUser.YourField;
            }
        }
