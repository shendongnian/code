    [Binding]
    public class TableSteps
    {
        [Given(@"below employee create a user\.")]
        public void GivenBelowEmployeeCreateAUser_(Table table)
        {
            Employee employee = new Employee(table.Rows[0][0], int.Parse(table.Rows[0][1]));
            Console.Write("Name:" + employee.Name); //Works as it is public.
            Console.Write("Name:"+ employee.EmpName); //No value returned here. Just null.
        }
    }
