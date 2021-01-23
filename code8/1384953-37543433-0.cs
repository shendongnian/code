    var authenticationType = "Cookies";
    var cookieName = "myCookieName";
    var cookieEncryptionKeyPath= "C:/mypath";
    var dataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo(cookieEncryptionKeyPath));
    var dataProtector = dataProtectionProvider.CreateProtector("Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware", authenticationType, "v2");
    var ticketDataFormat = new AspNetTicketDataFormat(new DataProtectorShim(dataProtector));
            
    app.SetDefaultSignInAsAuthenticationType(authenticationType);
    app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = authenticationType,
                CookieName = cookieName,
                TicketDataFormat = ticketDataFormat
            });
