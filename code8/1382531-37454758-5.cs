    public class Human
    {        
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
    public class Sportsman:Human
    {    }
    public class Employee:Human
    {    }
