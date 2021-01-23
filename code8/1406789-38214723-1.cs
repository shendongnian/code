    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Configure ComponentDesign & JobFile entity
        modelBuilder.Entity<ComponentDesign>()
            
            // Mark JobFile property optional in ComponentDesign entity.
            .HasOptional(cd => cd.DesignFile)
            
            // Mark ComponentDesign property optional in JobFile entity.
            .WithOptionalPrincipal(jf => jf.ComponentDesign); 
    }
