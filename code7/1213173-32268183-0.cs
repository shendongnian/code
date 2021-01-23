    public class Emp_Details : IEnumerable<Employee>
    {
        public List<Employee> lstEmployee { get; set; }
        public Emp_Details()
        {
            this.lstEmployee = new List<Employee>();
        }
        public IEnumerator<Employee> GetEnumerator()
        {
            return lstEmployee.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
