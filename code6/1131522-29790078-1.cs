    select new Match
    {
        ProjectID = b.ProjectID,
        ProjectName = b.ProjectName,
        ProjectStatus = b.ProjectStatus,
        EmployeeName = a.EmployeeName,
        EmployeeSurname = a.EmployeeSurname,
        ClientName = c.ClientName,
    }).ToList();
