        public ContractConfiguration()
        {
            HasKey(c => c.CustomerId);
            Map(m =>
            {
                m.Property(c => c.ContractId).HasColumnName("CONTRACT_ID");
                m.Property(c => c.CustomerId).HasColumnName("CUSTOMER_ID");
                m.ToTable("T_CONTRACTS");
            });
            Map(m =>
            {
                m.Property(cust => cust.CustomerId).HasColumnName("PERSON_ID");
                m.Property(cust => cust.CustomerName).HasColumnName("NAME");
                m.ToTable("T_PERSONS");
            });
        }
