    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Song>()
                   .HasMany<PlayList>(s => s.Playlists)
                   .WithMany(p => p.Songs)
                   .Map(cs =>
                            {
                                cs.MapLeftKey("PlayListID");
                                cs.MapRightKey("SongId");
                                cs.ToTable("PlayListSong");
                            });
    }
