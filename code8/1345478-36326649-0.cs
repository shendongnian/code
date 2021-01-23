    private readonly IApplicationEnvironment _env;
    public FileController(IApplicationEnvironment appEnv)
    {
        _env= appEnv;
    }
    public IActionResult Index()
    {
        var myModel = _env.ApplicationBasePath;
        return View(myModel);
    }
