    public ActionResult Index()
    {
        var viewModel = new DistrictViewModel() 
        {
            Districts = new SelectList(db.Districts.ToList(), "leaID", "name")
        }
        return View(viewModel);
    }
