    [HttpGet]
    public ActionResult MngBranch()
    {
        DbModel pdb = new DbModel();
        var model = new MyViewModel();
        model.BranchTypes = new SelectList(pdb.branchtypes, "Id", "Type");
        model.CompanyNames = new SelectList(pdb.companies, "IdCompany", "CompanyName");
        return View(model);
    }
    [HttpPost]
    public ViewResult MngBranch(MyViewModel model)
    {
        if (ModelState.IsValid)
        {
            return View("BranchSaved");
        }
        else
        {
            return View(model);
        }
    }
