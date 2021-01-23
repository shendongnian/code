    public class Context : DbContext, IContext
    {
        public Context() : base("MyContext") { }
        public virtual DbSet<Episodio> Episodio { get; set; }
        public virtual DbSet<Serie> Serie { get; set; }
        public virtual DbSet<SerieAlias> SerieAlias { get; set; }
        public virtual DbSet<Feed> Feed { get; set; }
    }
