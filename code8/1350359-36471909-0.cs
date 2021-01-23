    public class LoginInfo
    {
        public string Username { get; private set; }
        public string Password { get; private set; } 
    
        private LoginInfo() {}
    
        public LoginInfo(string login, string password)
        {
            this.Login = login; 
            this.Password = password;
        }
    }
    
    public class Student
    {
        public LoginInfo Logindata { get; private set; }
        public string PhoneNumber  { get; private set; }
      
        public student(string username, string password)
        {
            logindata = new LoginInfo(username, password);
        }
    
        public student(string email, string password, string phonenumber)
        {
            logindata = new LoginInfo(email, password);
            PhoneNumber = phonenumber;
        }
    }
