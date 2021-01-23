    var authenticationType = "Cookies";
    var cookieName = "myCookieName";
    var cookieEncryptionKeyPath= "C:/mypath";
     
    var protectionProvider = DataProtectionProvider.Create(new DirectoryInfo(cookieEncryptionKeyPath));
    var dataProtector = protectionProvider.CreateProtector("Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware", authenticationType, "v2");
    var ticketFormat = new TicketDataFormat(dataProtector);
    
    
    app.UseCookieAuthentication(
                    new CookieAuthenticationOptions
                    {
                        CookieName = options.CookieName,
                        CookieDomain = options.CookieDomain,
                        TicketDataFormat = ticketFormat
                    });
