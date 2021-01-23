    [XmlType("Student")]
    [XmlRoot("Student")]
    public class Student : Person
    {
        public int StudentId { get; set; }
        public List<string> Subjects { get; set; }
    }
    [XmlType("Employee")]
    [XmlRoot("Employee")]
    public class Employee : Person
    {
        public int EmployeeId { get; set; }
        public float Experience { get; set; }
    }
