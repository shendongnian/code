    public IActionResult Create()
    {
        var getDeptTitle = _context.Departments.ToList();
        var getBldgTitle = _context.Buildings.ToList();
        var viewModel = new MasterCreateViewModel()
                         {
                                 Departments = getDeptTitle,
	                             Buildings = getBldgTitle 
                         }
        return View(viewModel);
    }
