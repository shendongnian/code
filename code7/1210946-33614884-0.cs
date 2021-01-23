    private readonly IHostingEnviornment _hostEnvironment;
    
    public ProductsController(IHostingEnviornment hostEnvironment)
    {
       _hostEnvironment = hostEnvironment;
    }
    [HttpGet]
    public IEnumerable<string> Get()
    {
       FolderScanner scanner = new FolderScanner(_hostEnvironment.WebRoot);
       return scanner.scan();
    }
