    public class Student
    {
        public static int count = 0;
        public Student()
        {
            // Thread safe since this is a static property
            Interlocked.Increment(ref count);
        }
        // use properties!
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
    }
