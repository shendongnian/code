    var employees = Database.getEmployees();
    
    var employeesWithBoss = (from e in employees
                            join b in employees
                            on e.ID equals b.Boss into leftJoin
                            from boss in leftJoin.DefaultIfEmpty()
                            select new
                            {
                                Employee = e,
                                BossFirstName = boss == null ? null : boss.FirstName,
                                BossLastName = boss == null ? null : boss.LastName          
                            }).ToList();
    
    foreach (var employee in employeesWithBoss)
    {
        // do your normal work here, you now
        // have employee.BossFirstName and employee.BossLastName
    }
