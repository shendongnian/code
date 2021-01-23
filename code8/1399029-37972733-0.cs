    public EmployeeRecord[] Employees
    {
        get 
        {
            return CopyEmployeeRecords();   // slow code in property - bad
        }
    }
