    var innerjoinresult_as_employees_list =(from employee in DbSet
                                            join department in DbContext.Set<Departments>() 
                                            on employee.DepartmentID equals department.ID
                                            select new Employees { 
                                                       ID = employee.ID, 
                                                       FirstName =  employee.FirstName, 
                                                       LastName = employee.LastName,
                                                       DepartmentID = employee.DepartmentID, 
                                                       DepartmentName = department.Name }
                                            ).ToList();
