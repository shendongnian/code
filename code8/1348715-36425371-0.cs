     public class Employee
    {
        public int EmployeeId { get; set; }
        public int Skillssetpoints { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
    public class EmployeeModel
    {
        [JsonIgnore]
        public int EmployeeId { get; set; }
        public List<int> Skillssetpoints { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
 
