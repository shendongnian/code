    public class Customer
    {
        string firstName = "";
        string lastName = "";
        public Customer() { }
        public string FirstName { get { return firstName; } set { firstName = value ?? ""; } }
        public string LastName { get { return lastName; } set { lastName = value ?? ""; } }
    }
