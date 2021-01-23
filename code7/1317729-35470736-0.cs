    [WebMethod]
    public static List<Employee> getBirthday()
    {
        var db = new BLUEPUMPKINEntities();
        return (from emp in db.Employees
                where emp.EMP_DOB.Value >= DateTime.Now
                where emp.EMP_DOB.Value <= DateTime.Now.AddDays(15)
                select emp).ToList();
    }
