    public List<Employee> GetAllEmployees()
    {
        ebll employeeBll = new EmployeeBLL();
        return ebll.GetAllEmployees().OrderBy(e => e.LastName).ToList();
    }
