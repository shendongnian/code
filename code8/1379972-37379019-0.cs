    public class Song
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public virtual IList<Similarity> SimilaritiesWhereOriginal { get; set; }
        
        public virtual IList<Similarity> SimilaritiesWhereSimilar { get; set; } 
    }
    public class Similarity
    {
        public int Id { get; set; }
        public int OriginalId { get; set; }
        public virtual Song Original { get; set; }
        public int SimilarId { get; set; }
        public virtual Song Similar { get; set; }
    }
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Similarity> Similarities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasMany(x => x.SimilaritiesWhereOriginal).WithRequired(x => x.Original).WillCascadeOnDelete(false);
            modelBuilder.Entity<Song>().HasMany(x => x.SimilaritiesWhereSimilar).WithRequired(x => x.Similar).WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
