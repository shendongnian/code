    public class Category
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public int? ParentCategoryID { get; set; }
            public virtual ICollection<Category> Categories { get; set; }
            public virtual ParentCategory { get; set; }
        }
