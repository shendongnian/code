    public class Attachment : AttachmentBase
    {}
    public abstract class AttachmentBase
    {
        public const string StatePropertyName = "state";
        public Guid Id { get; set; }
    }
    public enum AttachmentState
    {
        Available,
        Deleted
    }
    public class AttachmentsDbContext : DbContext
    {
        public AttachmentsDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Attachment> Attachments { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<EntityEntry<Attachment>> softDeletedAttachments = ChangeTracker.Entries<Attachment>().Where(entry => entry.State == EntityState.Deleted);
            foreach (EntityEntry<Attachment> softDeletedAttachment in softDeletedAttachments)
            {
                softDeletedAttachment.State = EntityState.Modified;
                softDeletedAttachment.Property<int>(AttachmentBase.StatePropertyName).CurrentValue = (int)AttachmentState.Deleted;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttachmentBase>()
                .HasDiscriminator<int>(AttachmentBase.StatePropertyName)
                .HasValue<Attachment>((int)AttachmentState.Available);
            modelBuilder.Entity<AttachmentBase>().Property<int>(AttachmentBase.StatePropertyName).Metadata.IsReadOnlyAfterSave = false;
            modelBuilder.Entity<Attachment>()
                .ToTable("available_attachment");
            modelBuilder.Entity<AttachmentBase>()
                .ToTable("attachment");
            base.OnModelCreating(modelBuilder);
        }
    }
