    public IActionResult Create()
    {       
        ViewBag.Employees = new List<SelectListItem>
        {
            new SelectListItem {Text = "Shyju", Value = "1"},
            new SelectListItem {Text = "Bryan", Value = "2"},
            new SelectListItem {Text = "Sean", Value = "3"}
        };
        vm.EmployeeId = 2;  // This will set Bryan as selected
        return View(new MyViewModel());
    }
