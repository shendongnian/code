    public IActionResult Create()
    {
        ViewBag.DeptListName = GetDepartments();
        // Do the same for your other dropdown also
        return View();
     }
     private IEnumerable<SelectListItem> GetDepartments()
     {
          return context.Departments
                        .Select(s=> new SelectListItem { 
                                                         Value=s.DeptId.ToString(),
                                                         Text=s.DeptTitle })
                        .ToList();
     }
