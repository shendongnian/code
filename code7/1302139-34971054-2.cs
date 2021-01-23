    public class Employee
    {
        private string firstName;
        public Employee(string FName) //constructor
        {
            firstName = FName;
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName { get; set; }
    }
