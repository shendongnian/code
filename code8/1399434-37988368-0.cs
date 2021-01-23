	    public int id { get; set;}
		
        public string Custno { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
		
		// The table other fields are ignored...
        public List<CustomerAddress> Addresses { get; set; }
        
        }
    }
	
	 public class CustomerAddress 
    {
        public int id { get; set;}
		
        public int Customerid { get; set; }
		
		public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Cityname { get; set; }
        public string Statename { get; set; }
        public string Countryname { get; set; }
        public string Zipname { get; set; }
        public Customer Customer { get; set; }
    }
        public class CustomerMap()
        {
           
            ToTable("Customers");
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(k => k.Id);
            Property(p => p.Custno).HasMaxLength(8).IsRequired();
            Property(p => p.Name).HasMaxLength(120).IsRequired();
            Property(p => p.Balance).HasPrecision(18, 2);
           
            HasMany(a => a.Addresses).WithRequired(x => x.Customer).HasForeignKey(k => k.Customerid);  
        }
		
		 public class CustomerAddressMap()
        {
            
            ToTable("CustomerAddresses");
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(k => k.Id);
           
            Property(p => p.Address1).HasMaxLength(120);
            Property(p => p.Address2).HasMaxLength(120);
            Property(p => p.Cityname).HasMaxLength(40);
            Property(p => p.Countryname).HasMaxLength(40);
            Property(p => p.Statename).HasMaxLength(40);
            Property(p => p.Zipname).HasMaxLength(6);
        
            HasRequired(x => x.Customer).WithMany(a => a.Addresses).HasForeignKey(k => k.Customerid).WillCascadeOnDelete(false);
     
        }
		
		public class YourAppContext : DbContext
    {
        public YourAppContext()
            : base("YourAppContext")
        {
            Database.SetInitializer<YourAppContext>(null);     
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());            
            modelBuilder.Configurations.Add(new CustomerAddressMap());      
           
        }
      
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
       
    }
