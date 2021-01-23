    [XmlRoot("Employees")]
    public class EmployeesListSurrogate
    {
        [XmlElement("Employee")]
        public List<Person> EmployeeList { get; set; }
        public static implicit operator List<Person>(EmployeesListSurrogate surrogate)
        {
            return surrogate == null ? null : surrogate.EmployeeList;
        }
        public static implicit operator EmployeesListSurrogate(List<Person> employees)
        {
            return new EmployeesListSurrogate { EmployeeList = employees };
        }
    }
