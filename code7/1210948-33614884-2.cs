    private readonly IHostingEnvironment _hostEnvironment;
    
    public ProductsController(IHostingEnvironment hostEnvironment)
    {
       _hostEnvironment = hostEnvironment;
    }
    [HttpGet]
    public IEnumerable<string> Get()
    {
       FolderScanner scanner = new FolderScanner(_hostEnvironment.WebRootPath);
       return scanner.scan();
    }
