    public class Employee
    {
        private ThirdPartyEmployee _baseEmployee;
    
        public Employee() { _baseEmployee = new ThirdPartyEmployee(); }
        public Employee(ThirdPartyEmployee e) { _baseEmployee = e; }
    
        public string FirstName 
        { 
            get { return _baseEmployee.F_Name; }
            set { _baseEmployee.F_Name = value; }
        }
    
        ...
    }
