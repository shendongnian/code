    public IActionResult Index([FromServices] IHostingEnvironment hostingEnvironment)
    {
        var path = Path.Combine(hostingEnvironment.ContentRootPath, "Controllers", "TextFile.txt");
        return File(System.IO.File.OpenRead(path), contentType: "text/plain; charset=utf-8", fileDownloadName: "Readme.txt");
    }
