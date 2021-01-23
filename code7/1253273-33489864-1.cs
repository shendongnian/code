    public class EmployeeComparer : IEqualityComparer<Employee>
    {
         public bool Equals(Employee x, Employee y)
         {
             return String.Equals(x.PathSuffix, y.PathSuffix);
         }
         public int GetHashCode(Employee obj)
         {
             return obj.PathSuffix.GetHashCode();
         }
    }
