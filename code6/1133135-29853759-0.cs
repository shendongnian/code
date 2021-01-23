    public class Student : Person
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public static List<Student> AllStudents = new List<Student>();
        public Student()
        {
            AllStudents.Add(this);
        }
        public static int GetActiveInstances()
        {
            return AllStudents.Count;
        }
    }
