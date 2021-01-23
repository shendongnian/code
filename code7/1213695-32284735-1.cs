    Expression<Func<Department, DepartmentViewModel>> getViewModel = dep => 
        new DepartmentViewModel
        {
            Name = dep.Name,
            Location = dep.Location,
        };
