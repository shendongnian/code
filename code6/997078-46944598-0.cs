        if (dataProtectionProvider != null) {
            manager.UserTokenProvider =
               new DataProtectorTokenProvider<AppUser>
                  (dataProtectionProvider.Create("ConfirmationToken")) {
                   TokenLifespan = TimeSpan.FromHours(3)
                   //TokenLifespan = TimeSpan.FromSeconds(10);
               };
        }
