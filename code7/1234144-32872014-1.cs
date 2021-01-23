    public class User
    {
        public User(int userId)
        {
            // Do stuff
        }
    }
    
    public class Employee : User
    {
        public Employee(int employeeId) : base(GetUserId(employeeId))
        {
          
        }
        public static int GetUserId(int employeeId)
        {           
            return employeeId - 5;
        }
    }
