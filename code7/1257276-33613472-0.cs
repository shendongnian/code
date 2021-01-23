    // Create an EmployeeDTO that will be used as the model, 
    //i.e. parameter of your controller action
        public class EmployeeDTO
        {
        	public int a { get; set; }
            public int b { get; set; }
            public int c { get; set; }
        }
            
        // Create a factory that does the actual work 
        // of calling one of your Employee constructor
        public class EmployeeFactory
        {
        	public Employee GetEmployee(EmployeeDTO eDTO)   
            {
                //based on what values you recieve in the model i.e. EmployeeDTO, 
                //call the appropriate Employee Constructor
            }
        }
            
        // Your legacy class
        public class Employee
        {
            public Employee(int a) { }
            public Employee(int a, int b) { }
            public Employee(int a, int b, int c) {}
            //.. and so on
        }
