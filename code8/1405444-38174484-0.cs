        MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();
        if (string.IsNullOrEmpty(settings.HostName))
        {
            // This middleware is intended to be used locally for debugging. By default, HostName will
            // only have a value when running in an App Service application.
            app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
            {
                SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                TokenHandler = config.GetAppServiceTokenHandler()
            });
        }
