    protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<NoteTag>()
                    .HasKey(t => new { t.NoteId, t.TagId });
    
                modelBuilder.Entity<NoteTag>()
                    .HasOne(pt => pt.Note)
                    .WithMany(p => p.NoteTags)
                    .HasForeignKey(pt => pt.NoteId);
    
                modelBuilder.Entity<NoteTag>()
                    .HasOne(pt => pt.Tag)
                    .WithMany(t => t.NoteTags)
                    .HasForeignKey(pt => pt.TagId);
            }
