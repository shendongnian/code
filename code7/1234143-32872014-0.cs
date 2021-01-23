    public class User
    {
        public User(int UserId)
        {
            // Do stuff
        }
    }
    
    public class Employee : User
    {
        public Employee(int EmployeeId) : base(GetUserId(EmployeeId))
        {
          
        }
        public static int GetUserId(int EmployeeId)
        {           
            return EmployeeId - 5;
        }
    }
