    public partial class DairyCowBarnEntities : IdentityDbContext<ApplicationUser>
    {
        public DairyCowBarnEntities()
            : base("name=DairyCowBarnEntities")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public static DairyCowBarnEntities Create()
        {
            return new DairyCowBarnEntities();
        }
        public virtual DbSet<jntConcentrateMixture> jntConcentrateMixtures { get; set; }
        public virtual DbSet<jntConsistingParcel> jntConsistingParcels { get; set; }
    }
