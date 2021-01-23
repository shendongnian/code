    /// <summary>
    /// Build and return an employee from the provided data entity.
    /// </summary>
    /// <param name="fromDataEntity">The data entity from which the employee will be built.</param>
    /// <returns>Build and return an employee from the provided data entity.</returns>
    private static Employee BuildEmployee(EmployeeDataEntity fromDataEntity)
    {
        var employee = new Employee()
        {
            EmployeeCode = fromDataEntity.Code            
        };
        employee.WorksiteUserNameLazy = new Lazy<string>(() => GetEmployeeWorksiteUserName(employee));
        return employee;
    }
