    public partial class MyDbEntities : DbContext
    {
        public MyDbEntities()
            : base("name=MyDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Add the mapping class in here, instead of the setup
            modelBuilder.Configurations.Add(new UserMap());
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
        }
    
        public virtual DbSet<User> Users { get; set; }
    }
