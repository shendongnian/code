    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Your original setup goes here
            this.ToTable("Users");
            this.Property(u => u.Name).IsRequired().HasMaxLength(256);
            this.Property(u => u.Surname).IsRequired().HasMaxLength(256);
            this.Property(u => u.Email).IsRequired().HasMaxLength(200);
            this.Property(u => u.password).IsRequired().HasMaxLength(100);
            this.Property(u => u.address).IsRequired();
            this.Property(u => u.postcode).IsRequired();
            this.Property(u => u.number).IsRequired();
        }
    }
