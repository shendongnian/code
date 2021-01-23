    // get all active employees
    // assume active field is boolean
    List<MyTable> list = db.MyTables.Where(mt => mt.Active == true).ToList();
    
    if (selectParams.MinXIll > 0)
    {
        // filter result list to create another list contains proper data
        // assume TotalIll is your key value to determine how many illness on an employee
        var result = list.GroupBy(sb => sb.EmpId, sb => sb.MyId.Count()).Where(sb => sb.TotalIll >= selectParams.MinXIll).ToList();
    }
