    // wrong
    public ArtistMap()
    {
        ..
        HasMany(x => x.AlbumList)
           .Table("Album")
           .KeyColumn("AlbumId")         // wrong
           .Cascade.All().Not.LazyLoad();
    }
