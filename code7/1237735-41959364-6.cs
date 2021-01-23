    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      	modelBuilder.Entity<SubSpecialization>().HasRequired(c => c.Specialization)
          .WithMany(s => s.SubSpecializationDetails)
          .HasForeignKey(c => c.SID);
    }
