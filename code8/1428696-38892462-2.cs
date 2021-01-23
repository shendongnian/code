    var result = new List<Model3>();
    foreach(var e in from m1 in list1
            join m2 in list2 on m1.EmpGuid == m2.EmpGuid
            select new Model3 
            { 
                EmpGuid = m1.EmpGuid, 
                EmployeeeName1 = m1.EmployeeName,
                EmployeeeName2 = m2.EmployeeName,
                ...
            })
    {
        if(!String.IsNullOrEmpty(e.EmployeeName1)) 
            result.Add(new Model3 
            {
                EmpGuid = e.EmpGuid, 
                EmployeeName = e.EmployeeName1,
                ...
            });
        if(!String.IsNullOrEmpty(e.EmployeeName2)) 
            result.Add(new Model3 
            {
                EmpGuid = e.EmpGuid, 
                EmployeeName = e.EmployeeName2,
                ...
            })
    }
