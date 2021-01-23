        public class Category
    
     {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? ParentID { get; set; }
        [ForeignKey("ParentID")]
        public virtual List<Category> Subcategories { get; set; }
      }
    
