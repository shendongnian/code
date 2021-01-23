    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId {get;set;}
        public string ProductName {get;set;}
        public string ImagePath {get;set;}
        [InverseProperty("Product")]
        public virtual ICollection<Review> Reviews {get;set;}
    }
    [Table("Review")
    public class Review
    {
        [Key]
        public int ReviewId {get;set;}
        public int ProductId {get;set;}
        public string ReviewText {get;set;}
        [ForeignKey("ProductId")]
        public virtual Product Product {get;set;}
    }
