    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("TM_USER");
    
            Property(p => p.Key).HasColumnName("USR_USER_KEY");
            Property(p => p.Id).HasColumnName("USR_ID");
            Property(p => p.Username).HasColumnName("USR_USER_NAME");
            Property(p => p.Forename).HasColumnName("UDT_FORENAME");
            Property(p => p.Surname).HasColumnName("UDT_SURNAME");
            Property(p => p.IsApproved).HasColumnName("USR_ISAPPROVED");
           
            HasKey(user => user.Id);
        }
    }
