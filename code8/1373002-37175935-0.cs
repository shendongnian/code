    public class ItemModel
        {
            [Key]
            public int ID { get; set; }
            public string Description { get; set; }
            public string ModelNum { get; set; }
    
            //[ForeignKey("Category")]
            //public Int32 CategoryId { get; set; }
            //public virtual Category Category { get; set; }
    
            [ForeignKey("SubCategory")]
            public Int32 SubCategoryId { get; set; }
            public virtual SubCategory SubCategory { get; set; }
    
            [ForeignKey("Manufacturer")]
            public Int32 ManufacturerId { get; set; }
            public virtual Manufacturer Manufacturer { get; set; }
        }
    
        public class Category
        {
            [Key]
            public int ID { get; set; }
            public string CategoryName { get; set; }
            public virtual ICollection<SubCategory> SubCategories { get; set; }
        }
    
        public class SubCategory
        {
            public int ID { get; set; }
            public string SubCategoryName { get; set; }
    
            [ForeignKey("Category")]
            public int CategoryID { set; get; }
            public virtual Category Category { get; set; }
        }
    
        public class Manufacturer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
