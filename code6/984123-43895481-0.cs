         string f = summary.ToString("MM/dd/yyyy");
         summary= Convert.ToDateTime(f); // time at 12:00 start date
         var details = Uow.EmployeeAttendances.GetAllReadOnly()
        .Where(a=>a.EmployeeId== summary.EmployeeId &&
        a.Timestamp == summary).ToList();
 
