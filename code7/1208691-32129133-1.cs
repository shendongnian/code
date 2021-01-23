    private readonly IApplicationEnvironment _app;
    public HomeController(IApplicationEnvironment app)
    {
       _app = app;
    }
    public IActionResult Index()
    {
       var path = _app.ApplicationBasePath;
    }
