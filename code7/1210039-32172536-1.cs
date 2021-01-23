    namespace WpfApplication1
    {
        class DataAccessClass
        {
            readonly List<EmployeeList> _employeeList;
    
            public DataAccessClass()
            {
                if (_employeeList == null)
                {
                    _employeeList = new List<EmployeeList>();
                }
    
                _employeeList.Add(EmployeeList.CreateEmployee("MD", "Mishu", "M", "72000"));
                _employeeList.Add(EmployeeList.CreateEmployee("MD", "Mou", "F", "82000"));
                _employeeList.Add(EmployeeList.CreateEmployee("Jill", "Jack", "M", "92000"));
                _employeeList.Add(EmployeeList.CreateEmployee("John", "Smith", "M", "85000"));
                _employeeList.Add(EmployeeList.CreateEmployee("Amanda", "Scholl", "F", "49000"));
    
            }
    
            public List<EmployeeList> GetEmployeeInfo()
            {
                return new List<EmployeeList>(_employeeList);
            }
        }
    
        internal class EmployeeList
        {
            public string FirstName { get; private set; }
            public string LastName { get; private set; }
            public string Gender { get; private set; }
            public string Salary { get; private set; }
    
            public static EmployeeList CreateEmployee(string firstName, string lastname, string gender, string salary)
            {
                return new EmployeeList { FirstName = firstName, LastName = lastname, Gender = gender, Salary = salary };
            }
        }
    }
