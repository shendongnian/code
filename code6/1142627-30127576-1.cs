    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    	//Prevent cyclic cascade on elements table
    	modelBuilder.Entity<Interaction>()
    		.HasRequired(i => i.CauseElement)
    		.WithRequiredDependent()
    		.WillCascadeOnDelete(false);
    	modelBuilder.Entity<Interaction>()
    		.HasRequired(i => i.EffectElement)
    		.WithRequiredDependent()
    		.WillCascadeOnDelete(false);
    
        //Create the links between the element, the key, and the collection
    	modelBuilder.Entity<Interaction>()
    		.HasRequired<Element>(i => i.CauseElement)
    		.WithMany(e => e.CauseElements)
    		.HasForeignKey(i => i.CauseID);
    	modelBuilder.Entity<Interaction>()
    		.HasRequired<Element>(i => i.EffectElement)
    		.WithMany(e => e.EffectElements)
    		.HasForeignKey(i => i.EffectID);
    
    	base.OnModelCreating(modelBuilder);
    }
