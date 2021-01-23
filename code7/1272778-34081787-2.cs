    ....
    maintenance ObjMaintenance = new maintenance 
    { 
        MaintenanceId = Guid.NewGuid(),
        ....
    };                   
    foreach (var i in TVM.Expenses)
    {
        i.ExpenseId = Guid.NewGuid(); // add this
        ObjMaintenance.Expenses.Add(i);
    }
    db.maintenances.Add(ObjMaintenance);
    db.SaveChanges();
