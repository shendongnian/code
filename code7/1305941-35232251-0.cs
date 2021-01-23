    var employeeTeam = Session.Query<EmployeeTeam>()
                              .Select(x => x)
                              .Where(x => x.Id != 0)
                              .ToList();
    var projectedTeam = employeeTeam.Select(x => new {x.Id});
