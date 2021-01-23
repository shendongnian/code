    public class User
    {
        public User(int UserId)
        {
            // Do stuff
        }
    }
    public class Employee : User
    {
        private Employee(int userID) : base(userID) { }
    
        public static Employee GetEmployee(int employeeID)
        {
            var userID = GetUserIDFromEmployeeID(employeeID);
            return new Employee(userID);
        }
    }
