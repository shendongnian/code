    from d in Skills
    where (d.SkillID == 5 || d.SkillID == 6 || d.SkillID == 7) // or is not supported
    select new
    {
        Description = d.Description,
        Employees = EmployeeSkills
                .Select(es => new 
                {
                    Level = es.Level,
                    YearsExperience = es.YearsOfExperience,
                    Emp = Employees.Single(emp => emp.EmployeeID == es.EmployeeID)                    
                })
                .Select(es => new 
                {
                    Level = es.Level,
                    YearsExperience = es.YearsExperience,
                    Name = es.Emp.FirstName + " " + es.Emp.LastName))                    
                })           
    }
