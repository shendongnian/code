    public IQueryable<DTOs.Employee> GetEmployees()
    {
        return this.AttemptOperation(context => 
            {
                // I commented here your old code:
                // IQueryable<DTOs.Employee> employees = context.Employees.Project().To<DTOs.Employee>();
                // This is our new code:
                var employees = context.Employees.Project()
                
                return employees.select(m=> new EmployeeDto {
                    property1 = m.property1,
                    property2 = m.property2
                }
            });
    }
