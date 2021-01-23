    public class User
    {
       public string Id { get; set; }
       public int? CreatedByUserId { get; set; }
       public virtual User CreatedBy { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       // add in configuration for table name, pk, etc
       modelBuilder.Entity<User>()
          .Property(p => p.CreatedByUserId)
          .HasColumnName("CreatedBy");
       modelBuilder.Entity<User>()
          .HasOptional(x => x.CreatedBy)
          .WithMany()
          .HasForeignKey(x => x.CreatedByUserId);
    }
