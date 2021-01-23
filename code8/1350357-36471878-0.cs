    public class Student
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    
        public Student(string username, string password)
        {
            Username = username;
            Password = password;
        }
    
        public Student(string username, string email, string phoneNumber, string password)
        {
            Username = username;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
