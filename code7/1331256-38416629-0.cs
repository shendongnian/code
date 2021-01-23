    public IncludeDatabase() : base("mydb.db")
    {
    }
    
    public LiteCollection<Folder> Folders { get { return this.GetCollection<Folder>("Folders"); } }
    public LiteCollection<SubFolders> SubFolders { get { return this.GetCollection<Media>("SubFolders"); } }
    
    protected override void OnModelCreating(BsonMapper mapper)
    {
        mapper.Entity<SubFolder>()
            .DbRef(x => x.Folder, "Folders");
    }
