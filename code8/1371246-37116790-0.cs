    public ActionResult Index()
    {
        var model = TempData["CV "] as CV;
        return View();
    }
    public ActionResult rr()
    {
        CV _cv = new CV();
        _cv.education = new List<Education>();
        _cv.education.Add(new Education()
        {
            Faculty = "sa",
            OnGoing = false,
            Specialization = "asdasd",
            UniversityName = "sulxan",
            EndDate = DateTime.Now.AddDays(1),
            StartDate = DateTime.Now
        });
        TempData["CV"] = _cv;
        return RedirectToAction("Index");
    }
