    public AccountController(
        IFormsAuthentication formsAuth,
        IMembershipService service,
        ILocationRepository locationRepository)
    {
        FormsAuth = formsAuth ?? new FormsAuthenticationService();
        MembershipService = service ?? new AccountMembershipService();
        LocationRepository = locationRepository ?? new LocationRepository();
    }
    public IFormsAuthentication FormsAuth
    {
        get;
        private set;
    }
    public IMembershipService MembershipService
    {
        get;
        private set;
    }
 
    public ILocationRepository LocationRepository
    {
        get;
        private set;
    }
