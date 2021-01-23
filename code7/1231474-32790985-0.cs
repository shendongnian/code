    public class Reference
    {
        public int ReferenceId { get; set; }
        public int ByUserId { get; set; }
        public virtual User By { get; set; } // user who leaves a reference
        public int ToUserId { get; set; }
        public virtual User To { get; set; } // user who has given a reference
        public string Opinions { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Reference> ReferencedTo { get; set; } // collection of references that user has given
        public virtual ICollection<Reference> ReferencedBy { get; set; } // collection of references that user has been given
    }
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Reference> References { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reference>()
                .HasRequired(x => x.By)
                .WithMany(x => x.ReferencedBy)
                .HasForeignKey(x => x.ByUserId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Reference>()
                .HasRequired(x => x.To)
                .WithMany(x => x.ReferencedTo)
                .HasForeignKey(x => x.ToUserId)
                .WillCascadeOnDelete(false);
        }
    }
