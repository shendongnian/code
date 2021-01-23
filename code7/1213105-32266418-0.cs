        public PortalDbContext()
            : base("name=PortalConnectionString")
        {
            Database.SetInitializer<PortalDbContext>(null);
        }
