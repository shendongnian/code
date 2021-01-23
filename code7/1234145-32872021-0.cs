    public class User
    {
        public User(int userId)
        {
            Init(userId);
        }
    
        protected Init(int userId)
        {
            // Do stuff
        }
    
    }
    
    public class Employee : User
    {
        public Employee(int employeeId)  
        {
            // find user Id here
            Init(userId);
        }
    }
