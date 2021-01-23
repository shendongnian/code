    public class Company
    {
        [ExcelColumn("Company Title")] //maps the "Name" property to the "Company Title" column
        public string Name { get; set; }
    
        [ExcelColumn("Providence")] //maps the "State" property to the "Providence" column
        public string State { get; set; }
    
        [ExcelColumn("Employee Count")] //maps the "Employees" property to the "Employee Count" column
        public string Employees { get; set; }
    }
