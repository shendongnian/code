        public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(e => e.RowVersion).IsFixedLength().HasMaxLength(8).IsConcurrencyToken();
        }
    }
