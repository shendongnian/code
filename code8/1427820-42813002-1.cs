    public class LoginTypeConfiguration : EntityTypeConfiguration<Login>
    {
        public LoginTypeConfiguration()
        {
            this.Property(e => e.TeamMemberId)
                .HasColumnName("TeamMember_Id");
        }
    }
