    protected override void OnModelCreating(ModelBuilder builder)
      {
         builder.ForSqlServer().UseIdentity();
    
         builder.Entity<MediaFile>().ForRelational().Table("MediaFiles");
         builder.Entity<MediaFile>().Key(e => e.Uri);
         builder.Entity<MediaFile>().Index(e => e.Uri);
         builder.Entity<MediaFile>().Property(e => e.Title).MaxLength(256).Required();
    
         builder.Entity<PlaylistEntry<MediaFile>>().ForRelational().Table("MediaFileEntries");
         builder.Entity<PlaylistEntry<MediaFile>>().Key(e => e.Id);
         builder.Entity<PlaylistEntry<MediaFile>>().Reference(e => e.MediaFile).InverseReference();
     }
