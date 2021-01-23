    public static List<Employee> InsertEmployee(Employee e)
    {
        dataContext.Employees.Add(e);
        dataContext.SaveChanges();
        return GetAllEmployees();
    }
