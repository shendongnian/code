    private readonly ICompositeViewEngine _viewEngine;
    
            public AccountController(
            
                    UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager,
                    IEmailSender emailSender,
                    ISmsSender smsSender,
                    ILoggerFactory loggerFactory,
                    ICompositeViewEngine viewEngine)
                {
                    _userManager = userManager;
                    _signInManager = signInManager;
                    _emailSender = emailSender;
                    _smsSender = smsSender;
                    _logger = loggerFactory.CreateLogger<AccountController>();
                    _viewEngine = viewEngine;;
                }
