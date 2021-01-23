    public ActionResult Index(int compId)
    {
        var viewModel = 
            from c in db.Company
            join e in db.Employee on c.CompanyId equals e.Id
            where c.CompanyId == compId
            select new MyViewModel { Company = c, Employee = e };
        return View(viewModel);
    }
