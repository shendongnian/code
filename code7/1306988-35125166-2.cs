    public static void DeleteEmployee(int employeeId)
    {
        var dal = new Employee2Dal();
        dal.DeleteEmployee(employeeId); // modify dal method
    }
    public static void UpdateEmployee(int employeeId, string name, string gender, string city)
    {
        var dal = new Employee2Dal();
        dal.UpdateEmployee(employeeId, name, gender, city);
    }
