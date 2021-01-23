    public class EmployeeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static Func<Employee, EmployeeModel> Project = item => new EmployeeModel
        {
            ID = item.ID,
            Name = item.Name
        };
    }
