    public Employee this[int employeeid]
    {
        get
        {
            return Employees.FirstOrDefault(emp => emp.No == employeeid);
        }
    }
    
    public Employee this[string firstname]
    {
        get
        {
            return Employees.FirstOrDefault(emp => emp.FirstName == firstname);
        }
    }
