	public ActionResult Index(string CompanyID)
	{
		DentiCareEntities db = new DentiCareEntities();
		ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", CompanyID);	// preselect item in selectlist by CompanyID param
		if (!String.IsNullOrWhiteSpace(CompanyID))
		{
			return View();
		}
		return View(db.Treatments.Where(x => x.CompanyID == CompanyID).Take(50));
	}
