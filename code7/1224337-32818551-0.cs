    public class Auction
    {
        [ForeignKey("ActiveOne")]
        public int AuctionId { get; set; }
        public AuctionStatus AuctionStatus { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Required]
        public virtual ActiveAuction ActiveOne { get; set; } //match this name
    }
