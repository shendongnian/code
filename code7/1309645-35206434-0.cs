    public class BankAccount : IEntity
    {
        public int Id { get; set; }
        public long AccountNumber { get; set; }
        public string Description { get; set; }
        public bool IsFund { get; set; }
    
        public int OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public virtual Person Owner { get; set; }
        public int BranchID { get; set; }
        [ForeignKey("BranchID")]
        public virtual Branch Branch { get; set; }
    
        public BankAccount()
        {
            AccountNumber = 0;
            IsFund = false;
            Description = "Empty";
        }
    }
