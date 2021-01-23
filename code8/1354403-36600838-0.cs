    // Get employees list from the database
    var employees = db.Employee.Select(x => x.Id, x.Name).Tolist();
    // Put the employees in a SelectList
    var selectList = new SelectList(employees .Select(x => new { value = x.Id, text = x.Name }), "value", "text");}).ToList();
    // Pass the list to your ViewModel
    ObjVisitorsviewModel.Employees = selectList;
  
