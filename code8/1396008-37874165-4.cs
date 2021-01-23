    [Table(Name="Customer")]
    public class Customer
    {
    
        [Column(IsPrimaryKey = true)]
        public int ID { get; set; }
    
        [Column] 
        public string Name { get; set; }
    
        [Column]
        public string Address { get; set; }
    
    }
