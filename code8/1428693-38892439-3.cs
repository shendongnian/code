    List3.AddRange(List2.Where(l2 => List1.All(l1 => l1.EmpGuid != l2.EmpGuid)
                        .Select(l2 => new Model3 {
                             EmpGuid = l2.EmpGuid,
                             EmployeeName = l2.EmployeeName,
                             Anniversary = l2.Anniversary}));
