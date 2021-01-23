    public IActionResult Create()
    {
        var vm = new MyViewModel();
        vm.Employees = new List<SelectListItem>
        {
            new SelectListItem {Text = "Shyju", Value = "1"},
            new SelectListItem {Text = "Sean", Value = "2"}
        };
        return View(vm);
    }
