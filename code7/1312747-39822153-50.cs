    app.UseCookieAuthentication(new CookieAuthenticationOptions()
    {
        AuthenticationScheme = "MyCookieMiddlewareInstance",
        CookieName = "SecurityByObscurityDoesntWork",
        ExpireTimeSpan = new System.TimeSpan(15, 0, 0),
        LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Unauthorized/"),
        AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Forbidden/"),
        AutomaticAuthenticate = true,
        AutomaticChallenge = true,
        CookieSecure = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest,
        CookieHttpOnly = false,
        TicketDataFormat = new CustomJwtDataFormat("foo", tokenValidationParameters)
        // DataProtectionProvider = null,
        // DataProtectionProvider = new DataProtectionProvider(new System.IO.DirectoryInfo(@"c:\shared-auth-ticket-keys\"),
        //delegate (DataProtectionConfiguration options)
        //{
        //    var op = new Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions();
        //    op.EncryptionAlgorithm = Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_256_GCM:
        //    options.UseCryptographicAlgorithms(op);
        //}
        //),
    });
