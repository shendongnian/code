    public class MyComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.EmployeeNumber.Equals(y.EmployeeNumber);
        }
    
        public int GetHashCode(Employee x)
        {
            return x.EmployeeNumber.GetHashCode()
        }
    }
