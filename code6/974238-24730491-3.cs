    public class Username
    {
        [Index(IsUnique = true)]
        public int Id {get;set;}
        [Index(IsUnique = true)]
        public string Name {get;set;}
        public virtual ICollection<Page> PagesList{ get; set; }
    }
    public class Page {
        public int UsernameId { get; set; }
        // OtherProperties
        public virtual string Username {get;set;}
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            //one-to-many 
            modelBuilder.Entity<Page>().HasRequired<Username>(s => s.Username)
            .WithMany(s => s.PagesList)
            .WillCascadeOnDelete(true);
    }
