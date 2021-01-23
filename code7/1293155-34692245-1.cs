    public class JobEntityTypeConfiguration : EntityTypeConfiguration<Job>
    {
        public JobEntityTypeConfiguration()
        {
            HasKey(x => x.JobId);
            Property(x => x.JobId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
            HasOptional(x => x.Client).WithMany(x => x.Jobs);
        }
    }
