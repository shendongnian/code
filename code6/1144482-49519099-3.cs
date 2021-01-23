    OnValidateIdentity = delegate(CookieValidateIdentityContext context) {
                var stampValidator = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser, int>(
                    validateInterval: TimeSpan.FromMinutes(30),
                    regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager),
                    getUserIdCallback: (id) => (id.GetUserId<int>())
                );
                Task result = stampValidator.Invoke(context);
                int my_custom_minutes = 60; // run your logic here.
                    // set it at GLOBAL level for all (future) users.
                    context.Options.ExpireTimeSpan = TimeSpan.FromMinutes( my_custom_minutes );
                    // set it for the current user only.
                    context.Properties.ExpiresUtc = context.Properties.IssuedUtc.Value.AddMinutes( my_custom_minutes );
                return result;
    }
