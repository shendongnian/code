    // get all active employees
    // assume active field is boolean
    List<MyTable> list = db.MyTables.Where(mt => mt.Active == true).ToList();
    
    if (selectParams.MinXIll > 0)
    {
        // filter result list to create another list contains proper data
        // assume illness as a field to determine how many illness should be counted
        var result = list.GroupBy(sb => sb.EmpId).Where(sb => sb.Illness >= selectParams.MinXIll).ToList();
    }
