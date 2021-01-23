    public class EmailDbContext : DbContext
    {
        public DbSet<EmailState> Emails { get; set; }
        public DbSet<AttachmentState> Attachments { get; set; }
    }
