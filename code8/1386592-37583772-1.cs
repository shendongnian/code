    public class Student
    {
        public Student(string firstName = null, string lastName = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    //it's working fine
    //var danny = new Student("danny", "chen");
    //as the business grows a lot of students need a middle name
    public Student(string firstName = null, string middleName = null, string lastName = null)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
    }
    //for a better sequence the programmer adds middleName between the existing two, bang!
    
