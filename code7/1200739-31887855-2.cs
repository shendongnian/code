    public ActionResult Index()
    {
        var files = System.IO.Directory.GetFiles(@"C:\", "*.pdf")
                        .Select(x => System.IO.Path.GetFileNameWithoutExtension(x))
                        .ToList();
        return View(files);
    }
    public FileStreamResult ObtenerPdf(string file)
    {
        FileStream fs = new FileStream("c:\\" + file + ".pdf", FileMode.Open, FileAccess.Read);
        return File(fs, "application/pdf");
    }
