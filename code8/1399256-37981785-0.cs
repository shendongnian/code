    using System.Data.Entity;
    
    namespace MvcMusicStore.Models
    {
        public class MusicStoreEntities : DbContext
        {
            public MusicStoreEntities()
                : base("MusicStoreEntities")
            {
            
            }
            public DbSet<Album> Albums { get; set; }
            public DbSet<Genre> Genres { get; set; }
            
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Album>().ToTable("Album");
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Genre>().ToTable("Product");
                base.OnModelCreating(modelBuilder);
            }
            
            public static MusicStoreEntities Create()
            {
                return new MusicStoreEntities();
            }
        }
    }
