    public ActionResult Index()
    {
        var root = AppDomain.CurrentDomain.BaseDirectory;
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader( root + @"/Content/Site.css");
        var fileLines = new List<string>();
        while ((line = file.ReadLine()) != null)
        {
            fileLines.Add(line);
        }
        // You can use model, temdata or viewbag to carry your data to view.
        ViewBag.File = fileLines;
        return View();
    }
