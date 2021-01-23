    [Route("Company/Staff/{id}")]
    public ActionResult Details(int id)
    {
        var viewModel = 
            from c in db.Company
            join e in db.Employee on c.CompanyId equals e.Id
            where c.CompanyId == id
            select new MyViewModel { Company = c, Employee = e };
        return View(viewModel);
    }
