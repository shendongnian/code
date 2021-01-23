    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte DurationInMonths { get; set; }
        public short Fee { get; set; }
        public byte Discount { get; set; }
        
        public virtual ICollection<Customer> Customers {get; set;}//this needs to be present 
                    //otherwise EF is not able to know what type of relationship to create
    }
   
