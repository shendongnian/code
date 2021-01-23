    public HomeController(IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [Authorize(Roles = "SomeRole")]
    public IActionResult Performance()
    {
        return PhysicalFile(Path.Combine(_hostingEnvironment.ContentRootPath,
                                         "www", "MyStaticFile.pdf"), "application/pdf");
    }
