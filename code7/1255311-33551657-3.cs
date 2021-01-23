    @model YourNamespaceHere.CreateUserVM
    @using(Html.BeginForm())
    {
      @Html.DropdownListFor(s=>s.SelectedDept,Model.Departments,"Select on")
      @Html.TextBoxFor(s=>s.Name)
      <input type="submit" />
    }
    [HttpPost]
    public ActionResult Create(CreateUserVM model)
    {
        if (ModelState.IsValid)
        {
            //Map the view model to entity
            var emp = new Employee();
            emp.Name = model.Name;
            emp.DepartmentId = model.SelectedDept;
            db.Employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }    
        employee.Departments = GetDeperatements();
        return View(employee);
    }
