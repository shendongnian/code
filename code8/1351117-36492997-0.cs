    public class Order
    {
        ...
        public virtual ICollection<Employee> Employees { get; set; }
    }
    
    public class Employee
    {
        ...
        public virtual ICollection<Order> Orders { get; set; }
    }
