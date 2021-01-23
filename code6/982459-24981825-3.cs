    public AlbumMap()
    {
        ..
        References(x => x.Artist)
           .Column("ArtistId")
           .ForeignKey("ArtistId")
           .Fetch.Join();
    }
