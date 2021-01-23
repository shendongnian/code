    public class User
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Contact> ContactUsers { get; set; }
    }
    modelBuilder.Entity<Contact>()
        .HasOne(x => x.User)
        .WithMany(x => x.Contacts)
        .HasForeignKey(x => x.UserId);
    modelBuilder.Entity<Contact>()
        .HasOne(x => x.ContactUser)
        .WithMany(x => x.ContactUsers)
        .HasForeignKey(x => x.ContactUserId)
        .OnDelete(DeleteBehavior.Restrict);
