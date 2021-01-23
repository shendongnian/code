    var emp = dbContext.Employees.FirstOrDefault(x => x.EmployeeID == employeeID);
    
                dbContext.Companies.FirstOrDefault(x => x.CompanyID == companyID).SalaryTabs.Employee.Remove(emp);
    
                dbContext.SaveChanges();
