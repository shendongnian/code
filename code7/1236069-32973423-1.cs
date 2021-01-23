    List<User> users = new List<User>();
        var demoDepartment = context.Department.FirstOrDefault(x => x.Name.Equals("HR", StringComparison.OrdinalIgnoreCase))
        
                    users.Add(new User()
                    {
                        DepartmentId = demoDepartment.Id,
                        Name="John",
                        // All properties
                        IsActive = true
                    });
        
                  users.Add(new User()
                    {
                        DepartmentId = demoDepartment.Id,
                        Name="Smith",
                        // All properties
                        IsActive = true
                    });
    
    context.Users.AddOrUpdate(p => new { p.DepartmentId, p.EmployementType }, users.ToArray());
