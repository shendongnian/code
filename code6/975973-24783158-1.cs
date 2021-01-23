    public class Visit
    {
        public Guid VisitKey { get; set; }
        public ICollection<VisitActivityLog> VisitActivityLogs { get; set; }
    }
    public class VisitActivityLog
    {
        public Guid LogKey { get; set; }
        public Visit Visit { get; set; }
    }
    public class VisitConfiguration : EntityTypeConfiguration<Visit>
    {
        public VisitConfiguration()
        {
            ToTable("Visits");
            HasKey(visit => visit.VisitKey);
            HasMany(visit => visit.VisitActivityLogs)
                .WithRequired(v => v.Visit)
                .Map(m => m.MapKey("VisitKey"))
                .WillCascadeOnDelete(false);
        }
    }
    public class VisitActivityLogConfiruration : EntityTypeConfiguration<VisitActivityLog>
    {
        public VisitActivityLogConfiruration()
        {
            ToTable("VisitsActivityLog");
            HasKey(log => log.LogKey);
        }
    }
