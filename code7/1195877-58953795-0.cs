      context.Patrol.AddRange(model);  // error
    entity.Property(e => e.Id)
                        .HasColumnName("ID")
                        .ValueGeneratedNever(); // old
    
    entity.Property(e => e.Id)
                        .HasColumnName("ID"); //remove ValueGeneratedNever()
                   
