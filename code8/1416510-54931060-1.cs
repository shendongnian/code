    public class ParentModel
    {
        public int Id { get; set; }
        // Id for single instance navigation property
        public int? ChildModelId { get; set; }
        // Single instance navigation property to ChildTable, identified by ChildModelId property as foreign key
        public virtual ChildModel ChildModel { get; set; }
        // Collection navigation property to ChildTable with identified by ParentId property
        public virtual ICollection<ChildModel> ChildModels { get; set; }
    }
    public class ChildModel
    {
        public int Id { get; set; }
        // Id for ParentModel property back to ParentTable
        public int ParentId { get; set; }
        // Single instance navigation property to ParentTable, identified by ParentId property as foreign key
        public virtual ParentModel ParentModel { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {   
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<ParentModel>()
                .ToTable("ParentTable");
            // Configure collection of ChildModels (ParentTable to ChildTable/one-to-many relationship)
            builder.Entity<ParentModel>()
                .HasMany(t => t.ChildModels)
                .WithOne(t => t.ParentModel)
                .HasForeignKey(t => t.ParentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<ChildModel>()
                .ToTable("ChildTable");
            // Configure single ChildModel navigation property on ParentModel (one-to-one relationship)
            builder.Entity<ParentModel>()
                .HasOne(t => t.ChildModel)
                .WithOne()
                .HasForeignKey(typeof(ParentModel), nameof(ParentModel.ChildModelId))
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
