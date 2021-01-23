    public class User
    {
        public User(int userId)
        {
            // Do stuff
        }
    }
    
    public class Employee : User
    {
        public Employee(int employeeId, int userId) : base(userId) // I don't know this value yet?
        {
            // This is where I would find the User Id, and would like to pass
            // it to the User class constructor.
        }
    }
    public class EmployeeRepository
    {
        public Employee GetEmployee(int employeeId)
        {
            using(var connection = new SqlConnection(..)
            {
                //blah blah blah
                return new Employee(employeeId, userId);
            }
        }
    }
