    private readonly IHostingEnvironment _app;
    public HomeController(IHostingEnvironment app)
    {
         _app = app;
    }
    public IActionResult Index()
    {
        var path = _app.WebRootPath;
    }
