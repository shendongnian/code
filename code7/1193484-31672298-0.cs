    public class Customer
    {
       public string CustomerName { get; set; }
       public string Address { get; set; }
       public override string ToString()
       {
            return CustomerName + "|" + Address;
       }
    }
