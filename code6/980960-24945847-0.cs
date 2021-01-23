    public class User
    {
       public User()
       {
          Groups = new List<Group>();
       }
       public virtual ICollection<Group> Groups { get; set; }
       ....
    }
    public partial class Group
    {
        public Group()
        {
            Members = new List<User>();
        }
        public virtual ICollection<User> Members { get; set; }
        ....
    }
    
    modelBuilder.Entity<User>()
        .HasRequired(u => u.Group)
        .WithMany(u => u.Members)
        .HasForeignKey(u => u.GroupID);
    
    modelBuilder.Entity<Group>()
        .HasRequired(g => g.GroupAdmin)
        .WithMany(g => g.Groups)
        .HasForeignKey(d => d.GroupAdminID);
