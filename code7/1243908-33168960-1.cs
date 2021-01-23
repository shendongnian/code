    public class Employee
    {
        public Employee(string email)
        {
            Email = email;
        }
        public string UserName => Email;
        public string Email { get; }
    }
