    public class SqliteDataGroup
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<SqliteDataItem> Items { get; set; }
    }
    public class SqliteDataItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ItemContent { get; set; }
        [ForeignKey(typeof(SqliteDataGroup))]
        public int SqliteDataGroupId { get; set; }
    }
