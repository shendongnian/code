    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Server=(local);Database=EfShardingTpt;Integrated Security=true";
            using (MyDbContext myDbContext = new MyDbContext(connStr))
            {
                // Drop and recreate database
                Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());
            }
            // Create ContactLinkCustomer
            using (MyDbContext myDbContext = new MyDbContext(connStr))
            {
                ContactLinkCustomer clc = new ContactLinkCustomer
                {
                    Contact_ID = Guid.Empty,
                    Contact_Link_ID = Guid.Empty,
                    Customer_ID = Guid.Empty,
                    Tenant_ID = Guid.Parse("00000000-0000-0000-0000-100000000000")
                };
                myDbContext.ContactLinkCustomers.Add(clc);
                myDbContext.SaveChanges();
            }
            WriteTenantIds(connStr);
            // Update through subtype
            using (MyDbContext myDbContext = new MyDbContext(connStr))
            {
                ContactLinkCustomer clc = myDbContext.ContactLinkCustomers.First();
                clc.Tenant_ID = Guid.Parse("00000000-0000-0000-0000-200000000000");
                myDbContext.SaveChanges();
            }
            WriteTenantIds(connStr);
            // Update through supertype
            using (MyDbContext myDbContext = new MyDbContext(connStr))
            {
                ContactLink cl = myDbContext.ContactLinks.First();
                cl.Tenant_ID = Guid.Parse("00000000-0000-0000-0000-300000000000");
                myDbContext.SaveChanges();
            }
            WriteTenantIds(connStr);
        }
        private static void WriteTenantIds(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Tenant_ID FROM ContactLink";
                Guid contactLinkTenantId = (Guid) cmd.ExecuteScalar();
                cmd.CommandText = "SELECT Tenant_ID FROM ContactLinkCustomer";
                Guid contactLinkCustomerTenantId = (Guid)cmd.ExecuteScalar();
                Console.WriteLine("{0} {1}", contactLinkTenantId, contactLinkCustomerTenantId);
            }
        }
    }
    class MyDbContext : DbContext
    {
        public MyDbContext(string connectionString) : base(connectionString)
        {
        }
        public virtual DbSet<ContactLink> ContactLinks { get; set; }
        public virtual DbSet<ContactLinkCustomer> ContactLinkCustomers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContactLink>()
                .HasKey(e => e.Contact_Link_ID);
            modelBuilder.Entity<ContactLinkCustomer>()
                .HasKey(e => e.Contact_Link_ID);
        }
    }
