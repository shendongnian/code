    public class Student : Person
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        // This is the "official" list. It's private so cannot be changed externally
        private static readonly List<Student> StudentList = new List<Student>();
        // This property returns a COPY of our private list
        public static List<Student> AllStudents
        {
            get
            {
                var copyOfList = new List<Student>();
                copyOfList.AddRange(StudentList);
                return copyOfList;
            }
        }
        public Student()
        {
            // Add the student to our private list
            StudentList.Add(this);
        }
        public static int StudentCount()
        {
            // Return the count from our private list
            return StudentList.Count;
        }
    }
