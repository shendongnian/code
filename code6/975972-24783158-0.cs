    public class VisitActivityLogConfiruration : EntityTypeConfiguration<UserAuthenticationInfo>
    {
        public VisitActivityLogConfiruration()
        {
            ToTable("VisitsActivityLog");
            HasKey(log => log.LogKey);
            HasRequired(log => log.Visit).WithMany().Map(m => m.MapKey("VisitKey")).WillCascadeOnDelete(false);
        }
    }
