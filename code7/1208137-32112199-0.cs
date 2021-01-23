    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category{get;set;}
    }
    
    public class ProductConfiguration: EntityTypeConfiguration<Product>
    {
       public ProductConfiguration()
       {
           ToTable("Products");
           HasKey(c=>c.Id);
           Property(c=>c.Id).HasDatabaseGenerated(DatabaseGeneratedOption.Identity);       
       }
    }
    
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    
    public class CategoryConfiguration: EntityTypeConfiguration<Category>
    {
       public CategoryConfiguration()
       {
           ToTable("Categories");
           HasKey(c=>c.Id);
           Property(c=>c.Id).HasDatabaseGenerated(DatabaseGeneratedOption.Identity);
           HasMany(c=>c.Products).WithRequired(p=>p.Category).HasForeignKey(p=>p.CategoryI);
           HasMany(c=>c.ChildCategories).WithOptional(c=>c.ParentCategory).HasForeignKey(p=>p.ParentCategoryId);
       }
    }
