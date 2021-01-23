    public class SomeConfiguration: EntityTypeConfiguration<Some>
    {
    
          public SomeConfiguration()
          {
              // Property/column will have a max of 10 & will be required
              this.Property(o => o.Code).HasMaxLength(10).IsRequired();
              // Property/column will have a max of 50 & will be required
              this.Property(o => o.Name).HasMaxLength(50).IsRequired().IsUnicode(false);
              // will be nullable in the db, with a foreign key of ExchangeID
              this.HasOptional(o => o.Exchange).WithMany().HasForeignKey(o => o.ExchangeId).WillCascadeOnDelete(false);    
          }
    }
