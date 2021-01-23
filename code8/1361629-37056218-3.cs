    [Given(@"below employee create a user\.")]
    public void GivenBelowEmployeeCreateAUser_(Table table)
    {
        Employee employee = table.CreateInstance<EmployeeRow>().ToEmployee();
        Console.Write("Name:" + employee.Name);
        Console.Write("Name:"+ employee.EmpName);
    }
