    modelBuilder.Entity<Event>(entity=> {
        entity.Property(e => e.EventId).HasColumnName("EventID");
        entity.HasKey(e => e.EventId);
        entity.HasIndex(e => e.EventId).HasName("For Full Text Indexing").IsUnique();
        entity.Property(e => e.Active).HasDefaultValue(false);
        entity.Property(e => e.EventCloseDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("'1/1/2038'");
        entity.Property(e => e.Name).HasMaxLength(1024);
        entity.Property(e => e.PaxAllocationLimit).HasDefaultValue(10000);
    });
