    List<ProjectQueryModel> queryResult = ...;
    List<ProyectViewModel> views = queryResult
        // Take all the rows that belong to one proyect
        .GroupBy(m => m.Proyect)
        // Convert every group into a ProyectViewModel
        // We'll need a contructor in ProyectViewModel that gives us a completly empty instance
        // Aggregate takes a starting point, and a function that takes that starting point, and passes it every element of the IEnumerable we're using. The return value of that function is the "new starting point".
        // Using this we'll build the Proyect from every row.
        .Aggregate(new ProyectViewModel(), (pvm, nxtRow) => {
            // Check if we haven't initialized the instance, and do so.
            if (pvm.ProyectId == null) pvm.ProyectId = nxtRow.Proyect;
            if (pvm.ProyectName == null) pvm.ProyectName = nxtRow.ProyectName;
            if (pvm.RoomId == null) pvm.RoomId = nxtRow.RoomId;
            if (pvm.RoomName == null) pvm.RoomName = nxtRow.RoomName;
            if (pvm.Employees == null) pvm.Employees = new List<ProyectEmployeeViewModel>();
            // If the row has an employee
            if (nxtRow.EmployeeId.HasValue) {
                // If the Employee is not yet on the Proyect add it
                if (!pvm.Employees.Any(e => e.EmployeeId == nxtRow.EmployeeId))                                
                {
                    // This constructor should create the empty List of Qualifications
                    pvm.Employees.Add(new ProyectEmployeeViewModel(nxtRow.EmployeeId.Value, nxtRow.EmployeeName);
                }
                // If the row has a qualification
                if (nxtRow.QualificationId.HasValue)
                {
                    // Find it's employee
                    pvm.Employees.First(e => e.EmployeeId == nxtRow.EmployeeId)
                    // Add the current row's qualification to the employee
                        .Qualifications.Add(new EmployeeQualificationsViewModel(nxtRow.QualificationId.Value, nxtRow.QualificationName, nxtRow.QualificationLevel.Value));
                }
            }
            // Return the Proyect with the changes we've made so we keep building it
            return pvm;
        });
        
