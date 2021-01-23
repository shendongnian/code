    var users = from s in userTable
                where s.EmployeeID == "10"
                group new {s} by new { s.EmployeeID, s.Department} into g
                select new MyClass
                {
                    EffectiveDate = g.Max(m => m.s.EffectiveDate), 
                    EmployeeID = g.Key.EmployeeID, 
                    Department = g.Key.Department
                    //Assuming that the type of Department is string
                    PreviousDepartment = (string)null
                };
    var result = users.ToList();
    for(int i = 1; i < result.Count; i++)
    {
        result[i].PreviousDepartment = result[i-1].Department;
    }
