    public class Bid {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BidID { get; set; }
    
        [Required]
        public decimal Amount { get; set; }
    
        //...etc.
    
        public int ListingID { get; set; }
    
        [ForeignKey("ListingID")]
        public Listing Listing { get; set; }
    
        //public Bid() {
        //    Listing = new Listing();
        //}
    }
