            var employee = _db.Employee.Find(id);
            var supervisor = _db.Supervisor.Find(employee.SupervisorID);
            var model = new EmployeeSupervisorViewModel()
            {
                EmployeeId = employee.EmployeeId,
                Department = employee.Department,
                FristName = employee.FirstName,
                LastName = employee.LastName,
                SupFirstName = supervisor.FirstName,
                SupLastName = supervisor.LastName,
                SupEmail = supervisor.Email,
                SupPhone = supervisor.Phone
            };
            return View(model);
