     public JsonResult MarkAsRead(long notificationId, string employeeNumber)
     {
         var employee = _session.Query<Employee>().FirstOrDefault(x => x.Number == employeeNumber);
         var error = EmployeeService.VerifyEmployee(_session, employee);
         if (errormessage.IsNotNullOrWhitespace())
             return Error(errormessage);
         NotificationService.SetNotificationAsRead(notificationId, employee);   
         return Success();
     }
