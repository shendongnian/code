    public abstract class RepoDocument
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }
    public class Document : RepoDocument
    {
        public string Name { get; set; }
        
        // ... Other fields here...
    }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RepoDocument>().ToTable("RepoDocument");
            modelBuilder.Entity<Document>().ToTable("DocumentRecord");
        }
