        public class User
        {
            public string Id { get; set; }
    
            public RegistrationStatus RegistrationStatus { get; set; }
        }
        public class UserConfiguration : EntityTypeConfiguration<User>
        {
            public UserConfiguration()
            {
                    this.Property(x => x.RegistrationStatus)
                    .HasColumnType("int")
                    .IsRequired();
            }
        }
        public enum RegistrationStatus
        {
            Pending = 1,
            Active = 2,
            Blocked = 3
        }
