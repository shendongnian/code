    var items = new List<EmployeeStatusChange>();
    items.Add(new EmployeeStatusChange { EmployeeId = 1, Status = Status.CheckIn, DateTime = new DateTime(2015, 1, 1, 9, 0, 0) });
    items.Add(new EmployeeStatusChange { EmployeeId = 1, Status = Status.Lunch, DateTime = new DateTime(2015, 1, 1, 10, 30, 0) });
    items.Add(new EmployeeStatusChange { EmployeeId = 1, Status = Status.CheckIn, DateTime = new DateTime(2015, 1, 1, 11, 0, 0) });
    items.Add(new EmployeeStatusChange { EmployeeId = 1, Status = Status.Lunch, DateTime = new DateTime(2015, 1, 1, 12, 0, 0) });
    items.Add(new EmployeeStatusChange { EmployeeId = 1, Status = Status.CheckIn, DateTime = new DateTime(2015, 1, 1, 13, 0, 0) });
    items.Add(new EmployeeStatusChange { EmployeeId = 1, Status = Status.CheckOut, DateTime = new DateTime(2015, 1, 1, 17, 0, 0) });
    items.CalculateHours();
