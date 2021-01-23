    public class Product
    {
       public Guid Id {get;set;}
       public ICollection<Reference> References {get;set;}
    } 
    
    public class Reference
    {
       public Guid Id {get;set;}
       public ICollection<Product> Products {get;set;}
    }
    modelBuilder.Entity<Product>()
                .HasMany(p => p.References)
                .WithMany(r => r.Products)
                .Map(pxar =>
                {
                    pxar.MapLeftKey("Product_Id");
                    pxar.MapRightKey("Reference_Id");
                    pxar.ToTable("ProductsXReferences");
                });
