    public List<Employee> GetEmployees()
    {
        using (MyContext context = new MyContext())
        {
            return context.Database.SqlQuery<EmployeeVM>("select E.EmployeeId, E.EmployeeName,
     C.CustomerName from Employee E left join Customer C on E.CustomerId = C.CustomerId")
        .Select(x=> new Employee(){
            EmployeeId = x.EmployeeId,
            EmployeeName = x.EmployeeName,
            CustomerName = x.CustomerName
            }).ToList();
        }
    }
