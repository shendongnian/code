    public ActionResult Index()
    {
        CV model = (CV)TempData["cv"];
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
		TempData["cv"] = _cv;
        return RedirectToAction("Index");
    }
