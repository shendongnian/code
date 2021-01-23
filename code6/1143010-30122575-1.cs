    var empRowsEmpName = dsEmp.Tables[0].AsEnumerable().Select(r => r.Field<string>("EmpName"));
    var allRowsEmpName = dsAllTables.Tables[2].AsEnumerable().Select(r => r.Field<string>("EmpName"));
    IEnumerable<string> allIntersectingEmpNames = empRowsEmpName.Intersect(allRowsEmpName);
    if (allIntersectingEmpNames.Any())
    {
    }
