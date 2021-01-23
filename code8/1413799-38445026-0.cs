         var innerJoinQuery =
                    (from employee in DbSet
                    join department in DbContext.Set<Departments>() on employee.DepartmentID equals department.ID
                    select new Employees{ ID = employee.ID, FirstName = employee.FirstName, LastName = employee.LastName, DepartmentID = employee.DepartmentID, DepartmentName = department.Name }).ToList();
    
    List<Employees> employees = new List<Employees>(innerJoinQuery);
