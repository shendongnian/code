    [Table("Customer")]
    public partial class Customer
    {
        public int Id { get; set; }
    
        [StringLength(50)]
        public string Name { get; set; }
    
        public int? Adress_id { get; set; }
    
        public Adress Adress { get; set; }
    }
