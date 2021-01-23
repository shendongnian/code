    using (var db = new EmployeeDBContext())
    {
        Database.SetInitializer<EmployeeDBContext>(new DepartmentInitializer());
        var depts = db.Departments.ToList();
    }
