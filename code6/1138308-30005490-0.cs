    public class Employee
    {
        ...
        public virtual IList<Address> { get; set; }
    }
    public class Address
    {
        ...
        public virtual Employee Employee { get; set; }
    }
