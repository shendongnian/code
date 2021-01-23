    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            HasKey(u => u.Id);
            ToTable("AspNetUsers");
        }
    }
