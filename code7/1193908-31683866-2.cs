    var employee=db.EmployeeDetails
      .IsActive()
      .Include(x=>x.Manager);
    foreach(var e in employee) { 
      Console.Writeline("{0}'s manager is {1}",
        e.name,
        e.Manager.name);
    }
