    public class Review
    {
        [HiddenInput(DisplayValue=false)]
        public int ReviewId { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        [ForeignKey("ProductID")]
        publiv virtual Product {get;set;}
    }
