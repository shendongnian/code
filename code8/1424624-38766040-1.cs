    public Employee GetEmployee(int? employeeid = null, string firstname = null)
    {
        return employeeid.HasValue ? GetEmployeeById(employeeid.Value)
                                    : GetEmployeeByName(firstname);
    }
    
    private Employee GetEmployeeById(int employeeid)
    {
    
    }
    
    private Employee GetEmployeeByName(string firstname)
    {
    
    }
