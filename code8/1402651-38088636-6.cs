    public class EmployeeMap :  CsvHelper.Configuration.CsvClassMap<Employee>
    {
        public EmployeeMap()
        {
            Map(m => m.FirstName).Index(0);
            Map(m => m.LastName).Index(1);
            Map(m => m.Wage).Index(2);
        }
    }
