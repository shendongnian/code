        [XmlInclude(typeof(Student)), XmlInclude(typeof(Employee))]
        [XmlRoot("Employee")]
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
        }
        [XmlType("Student")]
        public class Student : Person
        {
            public int StudentId { get; set; }
            public List<string> Subjects { get; set; }
        }
        [XmlType("Employee")]
        public class Employee : Person
        {
            public int EmployeeId { get; set; }
            public float Experience { get; set; }
        }
