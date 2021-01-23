    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
    
    // delete symptoms
    modelBuilder.Entity<DatapultData.Model.UserSickness>()
    .HasOptional(a => a.Symptoms)
    .WithRequired(b => b.UserSicknessAsociated)//Update this line
    .WillCascadeOnDelete(true);
    
    base.OnModelCreating(modelBuilder);
    }
