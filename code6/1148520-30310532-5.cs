    public class CustomerRelationshipMap : EntityTypeConfiguration<CustomerRelationship>
    {
        public CustomerRelationshipMap()
        {
            ToTable("tblCustomerRelationship");
            Map<EmploymentRelationship>(m => m.Requires("CustomerRelationshipTypeID").HasValue(55));
            Map<ExpenseRelationship>(m => m.Requires("CustomerRelationshipTypeID").HasValue(60));
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("CustomerRelationshipID");
            Property(t => t.CustomerId).HasColumnName("CustomerID");
            Property(t => t.RelatedId).HasColumnName("RelatedID");
        }
    }
