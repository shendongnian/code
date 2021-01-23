    public abstract class UserMap<TUser> : EntityTypeConfiguration<TUser>
        where TUser : User
    {
        public UserMap()
        {
            // Table Mapping
            ToTable("Users");
            this.Property(x => x.Username).HasColumnName("Username");
    
    
            // Other mapping goes here
        }
    }
