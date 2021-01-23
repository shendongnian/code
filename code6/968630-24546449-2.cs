    public class MyRoot
    {
        public List<Student> p = new List<Student>();
    }
    public class Student
    {
        public List<Cars> c = new List<Cars>();
    }
    public class Cars
    {
        public String carYear { get; set; }
        public String carMake { get; set; }
        public String carModel { get; set; }
        public String carColor { get; set; }
        public String carMileage { get; set; }
    }
