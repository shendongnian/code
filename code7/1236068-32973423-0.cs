    var demoDepartment = context.Department.FirstOrDefault(x => x.Name.Equals("HR", StringComparison.OrdinalIgnoreCase))
    
                demoDepartment.Users.Add(new User()
                {
                    DepartmentId = demoDepartment.Id,
                    Name="John",
                    // All properties
                    IsActive = true
                });
    
              demoDepartment.Users.Add(new User()
                {
                    DepartmentId = demoDepartment.Id,
                    Name="Smith",
                    // All properties
                    IsActive = true
                });
