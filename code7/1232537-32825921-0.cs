    private Employee searchForEmployee(int ID)
    {
        var EmployeeDetails = (from emp in EmployeeArray
                               where emp.m_EmployeeId == ID
                               select emp).FirstOrDefault();
        if (EmployeeDetails != null)
        {
            return EmployeeDetails;
        }
        else
        {
            return new Employee
            {
                ID = 0,
                Name = "default", //etc
            };
        }
    }
