    modelBuilder.Entity<Team>()
        .HasKey(i => i.TeamId);
    //if you want to make the teamId an auto-generated column
    modelBuilder.Entity<Team>()
         .Property(i => i.TeamId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    //if you want to make the cat, dog, and pig combination unique
    modelBuilder.Entity<Team>()
        .Property(i => i.CatId)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(
            new IndexAttribute("IX_TeamComp", 1) { IsUnique = true }));
    
    modelBuilder.Entity<Team>()
        .Property(i => i.DogId)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(
            new IndexAttribute("IX_TeamComp",2) { IsUnique = true }));
    
    modelBuilder.Entity<Team>()
        .Property(i => i.PigId)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(
            new IndexAttribute("IX_TeamComp", 3) { IsUnique = true }));
