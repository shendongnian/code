    public IActionResult Create()
    {       
        ViewBag.Employees = new List<SelectListItem>
        {
            new SelectListItem {Text = "Shyju", Value = "1"},
            new SelectListItem {Text = "Sean", Value = "2"}
        };
        return View(new MyViewModel());
    }
