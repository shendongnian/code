    public class Customer
    {
    [XmlIgnore,JSonIgnore]
    public virtual ICollection<Customer> Children { get; set; }
    
    public string Name { get; set; }
    }
