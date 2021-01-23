    public class Item
    {
        public int ItemId { get; set; }
        [Display(Name = "Current name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(160)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }
        
    }
