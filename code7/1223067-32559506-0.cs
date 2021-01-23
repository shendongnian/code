    public class Context : DbContext {
    
      public IDbSet<Student> Students { get; set; }
    
      public IDbSet<Parent> Parents { get; set; }
    
      public IDbSet<Address> Addresses { get; set; }
    
      protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        modelBuilder
          .Entity<Student>()
          .HasRequired(p => p.Father);
        modelBuilder
          .Entity<Student>()
          .HasRequired(p => p.Guardian);
        modelBuilder
          .Entity<Student>()
          .HasRequired(p => p.PermanentAddress);
        modelBuilder
          .Entity<Student>()
          .HasRequired(p => p.TemporaryAddress);
        modelBuilder
          .Entity<Parent>()
          .HasRequired(p => p.PermanentAddress);
        modelBuilder
          .Entity<Parent>()
          .HasRequired(p => p.TemporaryAddress);
      }
    
    }
