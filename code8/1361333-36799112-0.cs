    public ActionResult Index()
    {
    using (var streamRead = System.IO.File.OpenRead(
        System.IO.Path.Combine(
            Server.MapPath("~/Documents"), 
            "index.html")))
            {
                return File(streamRead, "text/html");
            }
    }`
