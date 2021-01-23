    Expression<Func<Department, DepartmentViewModel>> getViewModel = dep => 
        new DepartmentViewModel
        {
            Name = dep.Name,
            Location = dep.Location,
        }
    var dvm = context.Departments.Select(getViewModel).Where(filterDVM);
