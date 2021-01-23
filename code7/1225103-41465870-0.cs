    container.Register<IUserTokenProvider<ApplicationUser, string>>(() =>
        new DataProtectorTokenProvider<ApplicationUser>
            (new DpapiDataProtectionProvider("MY APPLICATION NAME").Create("ASP.NET Identity"))
            {
                // all user tokens are only valid for 3 hours
                TokenLifespan = TimeSpan.FromHours(3)
            }, Lifestyle.Scoped);
