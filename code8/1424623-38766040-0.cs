    public Employee this[int employeeid = 0, string firstname = ""]
    {
        get
        {
            if (employeeid != 0)
            {
                return Employees.FirstOrDefault(emp => emp.No == employeeid);
            }
            else
            {
                return Employees.FirstOrDefault(emp => emp.FirstName == firstname);
            }
        }
    
    }
    
    public Employee this[int employeeid]
    {
        set
        {
            if (employeeid == value.No)
            {
                Employees.FirstOrDefault(emp => emp.No == employeeid).FirstName = value.FirstName;
                Employees.FirstOrDefault(emp => emp.No == employeeid).LastName = value.LastName;
            }
            else
            {
                ArgumentException argEx = new ArgumentException("Falied to update");
            }
        }
    }
