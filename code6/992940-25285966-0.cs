    [HttpPost]
    public ActionResult Index(CandidateModel Id)
    {
       TempData["var"] = id;
       return RedirectToAction ("Inscription","Candidate",Id);
    }
    public ActionResult Inscription()
    {
       var id = TempData["id"] as CandidateModel;
    }
