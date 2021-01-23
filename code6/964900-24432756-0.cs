    namespace MvcMusicStore.Models {
        public class MusicStoreEntities: DbContext {
            public MusicStoreEntities() : base("MusicStoreEntities")
            {
            }
            public DbSet<Album> Albums { get; set; }
            public DbSet<Genre> Genres { get; set; }
        }
    }
