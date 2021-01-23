    [XmlRoot("Employees")]
    public class Employees : List<Employee> { }
    public class Employee
    {
        int _id;
        string _firstName;
        string _lastName;
        int _salary;
        public Employee() { }
        public Employee(int id, string firstName, string lastName, int salary)
        {
            this._id = id;
            this._firstName = firstName;
            this._lastName = lastName;
            this._salary = salary;
        }
        [XmlElement("ID")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
    }
