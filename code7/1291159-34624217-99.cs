    public IActionResult Create()
    {
        var vm = new MyViewModel();
        vm.Employees = context.Employees
                              .Select(a => new SelectListItem() {  
                                                                   Value = a.Id.ToString(),
                                                                   Text = a.Name
                                                                })
                              .ToList();
        return View(vm);
    }
