    SampleDBContext db = new SampleDBContext();
    [HttpGet]
    public ActionResult Index()
    {
        Company company = new Company();
        company.SelectedDepartment = null;
        company.DepartmentList = db.Departments.ToList();
        return View("Index", company);
    }
    [HttpPost]
    public ActionResult Index(Company company)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        db.Companies.Add(company);
        db.SaveChanges();
        return RedirectToAction("Index")
    }
