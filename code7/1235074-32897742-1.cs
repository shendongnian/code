    modelBuilder.Configurations.Add(new BaseObjectConfiguration<Entity1>());
    modelBuilder.Configurations.Add(new BaseObjectConfiguration<Entity2>());
    modelBuilder.Configurations.Add(new BaseObjectConfiguration<Entity3>());
    modelBuilder.Configurations.Add(new BaseObjectConfiguration<Entity4>());
    ...
    
    // Specific mappings options for each entity:
    modelBuilder.Entity<Entity1>().HasRequired(t => t.NodeTypeEntity).
                    WithMany(t => t.Nodes).HasForeignKey(t => t.NodeTypeId);
                modelBuilder.Entity<NWatchNode>().HasOptional(t => t.Parent).
                    WithMany(t => t.Children).HasForeignKey(t => t.ParentId);
    ...
