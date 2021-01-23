    public IQueryable<BusinessModels.Report> GetReportsByEmployeeId(string employeeId)
    {
        return _reports // _reports is a collection of Type DomainModels.Report
                .GetAll()
                .Where(x => 
                     x.ManagerId.Equals(employeeId) 
                     || x.EmployeeId.Equals(employeeId))
                .Select(s =>
                   new BusinessModels.Report
                   {
                        Id = s.Id,
                        Employee = s.Employee,
                        Manager = s.Manager
                   })
                .ToList(); 
                // We don't want database access happening outside of the service. 
                // ToList() executes the SQL *now* rather than waiting until 
                // the first time you enumerate the result.
    }
