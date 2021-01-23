    public MyController : AsyncController
    {
      public Task<ActionResult> MyAction(...)
      {
        // if you don't use DI
        var userManager = new UserManager<ApplicationUser>(
          new UserStore<ApplicationUser>(
            new IdentityDataContext()));
        var registerBusiness = new RegisterBusiness(userManager, Session);
        var result = await registerBusiness.RegisterUser(...);
      }
    }
