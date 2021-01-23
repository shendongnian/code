    public class ContractConfiguration : EntityTypeConfiguration<Contract>
    {
        public ContractConfiguration()
        {
            ToTable("T_CONTRACTS", "ASSUROL"); //table and schema ALWAYS in uppercase
            HasKey(c => c.ContractId);  // Redundant since ContractId is key via convention
            Property(c => c.ContractId).HasColumnName("CONTRACT_ID").IsRequired();
            Property(c => c.PersonId).HasColumnName("CUSTOMER_ID").IsRequired();
    
            // Configure the relationship although EF should pick this up by convention as well...
            HasRequired(c => c.Customer).WithMany(p => p.Contracts);
    
        }
    }
