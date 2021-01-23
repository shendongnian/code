    public class EmployeeSpecificUsage : Employee
    {
        public string FirstName { get { return firstName; }};
        public string FullName { get { return string.Format("{0} {1}", firstName, lastName); }};
    }
    public class Employee
    {
        protected string firstName;
        protected string lastname;
        protected int age;
        protected string workTitle;
        protected string field1;
        protected string field2;
        protected string field3;
    }
