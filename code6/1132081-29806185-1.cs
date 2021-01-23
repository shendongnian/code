    [HttpPost]
    public ActionResult Index(ImageSwapModel imageSwap)
    {
        var oldFileFound = false;
        var newFileFound = false;
        if (ModelState.IsValid)
        {
            this.HttpContext.Session["ImageSwap"] = imageSwap;
        }
     }
