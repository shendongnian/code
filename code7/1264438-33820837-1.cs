    var sdt = new SecureDataFormat<AuthenticationTicket>(
        new TicketSerializer(), 
        new DpapiDataProtectionProvider().Create("ASP.NET Identity"), 
        TextEncodings.Base64);
    container.Options.AllowOverridingRegistrations = true;
    container.Register<AccountController>(() => 
        new AccountController(
            new ApplicationUserManager(
                new UserStore<ApplicationUser>(new ApplicationDbContext())), 
            sdt),
        Lifestyle.Scoped);
        
    container.Options.AllowOverridingRegistrations = false;
