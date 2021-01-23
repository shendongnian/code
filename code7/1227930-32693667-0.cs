    [Table(Name = "tvchannel")] // Here you put the name of the table in your database.
    private class TVChannelObject
    {
        Column(Name = "number", IsPrimaryKey = true)] // Here, number is the name of the column in the database and it is the primary key of the table.
        public string number { get; set; }
        [Column(Name = "title", CanBeNull = true)] // If the field is nullable, then you can set it on CanBeNull property.
        public string title { get; set; }
        [Column(Name = "channelFavorite", CanBeNull = true)] // Note that you can have a field in the table with a different name than the property in your class.
        public string favoriteChannel { get; set; }
        [Column(Name = "desc", CanBeNull = true)]
        public string description { get; set; }
        [Column(Name = "package", CanBeNull = false)]
        public string packageid { get; set; }
        [Column(Name = "format", CanBeNull = false)]
        public string format { get; set; }
    
    }
