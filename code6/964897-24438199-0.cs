    public class Account
    {
        [Key]
        public long ID { get; set; }
        public virtual Customer Customer { get; set; }
    }
    public class Customer
    {
        [Key]
        public long AccountID { get; set; }
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }
    }
