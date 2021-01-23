    [Table("Customer")]
    class Customer
    {
        [PrimaryKey, AutoIncrement]    
        [Column(Name = "CustomerId")]
        public int CustomerId { get; set; }
    
        .......
    }
