    public List<Employee> GetAllEmployees()
    {
        ebll employeeBll = new EmployeeBLL();
        return ebll.GetAllEmployees().OrderBy(e => e.<here use property that you want to order by>).ToList();
    }
