            var departments = new List<Department>();
            var employees = new List<Employee>();
            var result = employees
                            .Where(e => e.HireDate >= Convert.ToDateTime("1/15/2015"))
                            .Select(e => new Roster
                            {
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Gender = e.Gender,
                                HireDate = e.HireDate,
                                DepartmentId = departments.First(d => d.Employees.Any(ee => e.EmployeeId == e.EmployeeId)).DepartmentId,
                                DepartmentName = departments.First(d => d.Employees.Any(ee => e.EmployeeId == e.EmployeeId)).DepartmentName
                            });
