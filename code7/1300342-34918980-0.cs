    public abstract class Tracking
    {
        public Guid CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
    }
    public abstract class TrackingConfig<T> : EntityTypeConfiguration<T> where T: Tracking
    {
        public TrackingConfig()
        {
            HasRequired( t => t.CreatedBy )
                .WithMany()
                .HasForeignKey( t => t.CreatedById );
        }
    }
    public class Product : Tracking
    {
        public Guid Id { get; set; }
    }
    public class ProductConfig : TrackingConfig<Product>
    {
        public ProductConfig()
        {
        }
    }
...
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );
            modelBuilder.Configurations.Add( new ProductConfig() );
