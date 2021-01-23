    public class ProductEligibiltyConfiguration : EntityTypeConfiguration<ProductEligibilty>
    {
        public ProductEligibiltyConfiguration()
        {
            HasKey(t => t.Id).ToTable("ecom_ProductEligibilty");
            HasOptional(a => a.Product)
                .WithMany(t => t.MeetingProductEligibilty)
                .HasForeignKey(k => k.ProductId)
                .WillCascadeOnDelete(false);
            HasOptional(t => t.MemberType).WithMany().HasForeignKey(k => k.MemberTypeId).WillCascadeOnDelete(false);
        }
    }
