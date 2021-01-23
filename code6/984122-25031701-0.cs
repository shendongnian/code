    var from = summary.Date;
    var to = summary.Date.AddDays(1);
    var details = Uow.EmployeeAttendances
      .GetAllReadOnly()
      .Where(a => a.EmployeeId == summary.EmployeeId && a.Timestamp >= from && a.Timestamp< to)
      .ToList();
