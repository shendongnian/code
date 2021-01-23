        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MediaFile>().ForRelational().Table("MediaFiles");
            builder.Entity<MediaFile>().Key(e => e.Uri);
            builder.Entity<MediaFile>().Index(e => e.Uri);
            builder.Entity<MediaFile>().Property(e => e.Title).MaxLength(256).Required();
            builder.Entity<PlaylistEntry<MediaFile>>().ForRelational().Table("MediaFileEntries");
            builder.Entity<PlaylistEntry<MediaFile>>().Key(e => e.Uri);
            builder.Entity<PlaylistEntry<MediaFile>>().Reference(e => e.MediaFile).InverseReference().ForeignKey<PlaylistEntry<MediaFile>>(e => e.Uri);
        }
