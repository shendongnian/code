    StudentContext context = new StudentContext();
    var viewModels = context.Students
        .Include(s => s.Department) // tell EF to eager load the related department for each student
        .Select(s => new StudentViewModel // this make a projection to your view model
        {
            Student = s,
            DepartmentName = s.Department.DepartmentName
            // Set all properties you need
        }).ToList();
    return View(viewModels); 
