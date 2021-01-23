     var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider = new DataProtectorTokenProvider<CustomUser, int>(dataProtectionProvider.Create("FocusOnStoreService"))
                    {
                        TokenLifespan = TimeSpan.FromHours(2)
                    };
                }
