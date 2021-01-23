    public class Foo
    {
       public string LastName { get; set; }
       public EmployeeType EmployeeType { get; set; }
       public virtual Store Store { get; set; }
       public int AssignedStore { get; set; }
    }
    public enum EmployeeType
    {
        Employee,
        Manager
    }
